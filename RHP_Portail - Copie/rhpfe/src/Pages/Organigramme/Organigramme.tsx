import React, { useEffect, useState } from 'react';
import useAxiosPost from '../../hooks/useAxiosPost';
import { Box, Typography, Modal } from '@mui/material';
import './Organigramme.scss';
import Loading from '../../components/Loading/Loading';
import { colorBase } from '../../modules/module_general';

interface IOrgNode {
    Cod_Entite: string;
    Lib_Entite: string;
    Parent: string;
    Responsable?: string;
    Poste?: string;
    Nom?: string;
    Civilite?: string;
    Lib_Type_Entite?: string;
    Lib_Typ_Entite?: string;
    Type_Entite?: string;
    Typ_Entite?: string;
    Niveau?: number;
    Resp_Matricule?: string;
    Resp_Nom?: string;
    Resp_Titre?: string;
    Resp_Photo?: string;
    [key: string]: any;
}

interface ITreeNode extends IOrgNode {
    children: ITreeNode[];
}

const ENTITY_CONFIGS: Record<string, { label: string; level: number; color: string }> = {
    'BRCH': { label: 'Branche', level: 6, color: 'rgb(166, 255, 166)' },
    'DEPT': { label: 'Département', level: 4, color: 'rgb(115, 163, 185)' },
    'DIRE': { label: 'Direction', level: 2, color: 'rgb(82, 188, 252)' },
    'DIRG': { label: 'Direction Générale', level: 0, color: 'rgb(72, 119, 242)' },
    'DIRP': { label: 'Direction de Pôle', level: 1, color: 'rgb(137, 137, 197)' },
    'SDIR': { label: 'Sous-Direction', level: 3, color: 'rgb(168, 255, 255)' },
    'SRVC': { label: 'Service', level: 5, color: 'rgb(255, 170, 170)' },
};

const Organigramme = () => {
    const myAxios = useAxiosPost();
    const [treeData, setTreeData] = useState<ITreeNode | null>(null);
    const [loading, setLoading] = useState(true);
    const [selectedPhoto, setSelectedPhoto] = useState<string | null>(null);

    const treeRef = React.useRef<HTMLDivElement>(null);

    useEffect(() => {
        loadData();
    }, []);

    useEffect(() => {
        if (!loading && treeData && treeRef.current) {
            // Scroll to center the tree
            treeRef.current.scrollIntoView({ behavior: 'smooth', block: 'center', inline: 'center' });
        }
    }, [loading, treeData]);

    const loadData = async () => {
        try {
            setLoading(true);
            const response = await myAxios("get_organigramme", {
                cod_entite: ""
            });

            if (response && response.data.result) {
                const flatData: IOrgNode[] = response.data.data;
                const tree = buildTree(flatData);
                setTreeData(tree);
            }
        } catch (error) {
            console.error("Error loading organigramme", error);
        } finally {
            setLoading(false);
        }
    };

    const buildTree = (data: IOrgNode[]): ITreeNode | null => {
        if (!data || data.length === 0) return null;

        // Detect field names dynamically from the first item
        const firstItem = data[0];
        const idKey = Object.keys(firstItem).find(k => ['Cod_Entite', 'ID_Entite', 'Id_Entite', 'cod_entite', 'id'].includes(k)) || 'Cod_Entite';
        const parentKey = Object.keys(firstItem).find(k => ['Parent', 'Cod_Parent', 'ID_Parent', 'Id_Parent', 'cod_parent'].includes(k)) || 'Parent';

        const map = new Map<string, ITreeNode>();
        const roots: ITreeNode[] = [];

        // Initialize map
        data.forEach(item => {
            // @ts-ignore
            const id = item[idKey];
            map.set(id, { ...item, children: [] });
        });

        // Connect nodes
        data.forEach(item => {
            // @ts-ignore
            const id = item[idKey];
            const node = map.get(id);
            if (!node) return;

            // @ts-ignore
            const parentId = item[parentKey];

            // Check if parent exists in the map
            if (parentId && parentId !== id && map.has(parentId)) {
                const parent = map.get(parentId);
                parent?.children.push(node);
            } else {
                roots.push(node);
            }
        });

        return roots.length > 0 ? roots[0] : null;
    };




    const RecursiveTree = ({ node }: { node: ITreeNode }) => {
        const [expanded, setExpanded] = useState(true);
        const hasChildren = node.children && node.children.length > 0;

        const getConfig = (node: ITreeNode) => {
            const type = node.Typ_Entite || node.Type_Entite;
            if (type && ENTITY_CONFIGS[type]) {
                return ENTITY_CONFIGS[type];
            }
            return null;
        };
        const config = getConfig(node);
        const backgroundColor = config ? config.color : undefined;


        const level = config ? config.level : (node.Niveau || 0);

        return (
            <li style={{ "--after-h": `${level}` } as React.CSSProperties}>
                <div
                    className={`org-node`}
                    style={{ backgroundColor: backgroundColor, cursor: 'default' }}
                >
                    <span className="node-title">{node.Lib_Entite}</span>
                    {config && <span className="node-type" style={{ fontSize: '0.8em', opacity: 0.8, display: 'block' }}>{config.label}</span>}

                    {node.Resp_Matricule && (
                        <div className="node-manager-details" style={{ marginTop: '8px', borderTop: '1px solid rgba(0,0,0,0.1)', paddingTop: '4px', textAlign: 'center' }}>
                            {node.Resp_Photo ? (
                                <img
                                    src={node.Resp_Photo}
                                    alt={node.Resp_Nom}
                                    style={{ width: '50px', height: '50px', borderRadius: '50%', objectFit: 'cover', marginBottom: '4px', border: '2px solid white', boxShadow: '0 2px 4px rgba(0,0,0,0.1)', cursor: 'pointer' }}
                                    onClick={(e) => {
                                        e.stopPropagation();
                                        setSelectedPhoto(node.Resp_Photo || null);
                                    }}
                                />
                            ) : (
                                <div style={{ width: '50px', height: '50px', borderRadius: '50%', backgroundColor: 'rgba(255,255,255,0.5)', margin: '0 auto 4px', display: 'flex', alignItems: 'center', justifyContent: 'center', fontWeight: 'bold', color: '#555' }}>
                                    {node.Resp_Nom?.substring(0, 1)}
                                </div>
                            )}
                            <div style={{ fontWeight: 'bold', fontSize: '0.85em', lineHeight: '1.2' }}>{node.Resp_Nom}</div>
                            <div style={{ fontSize: '0.75em', fontStyle: 'italic', marginBottom: '2px' }}>{node.Resp_Titre}</div>
                            <div style={{ fontSize: '0.7em', opacity: 0.7 }}>{node.Resp_Matricule}</div>
                        </div>
                    )}

                    {!node.Resp_Matricule && node.Responsable && (
                        <span className="node-manager">
                            {node.Civilite} {node.Responsable} {node.Nom}
                        </span>
                    )}
                    {!node.Resp_Matricule && node.Poste && (
                        <span className="node-poste">{node.Poste}</span>
                    )}
                    {hasChildren && (
                        <div style={{
                            marginTop: '5px',
                            fontSize: '12px',
                            fontWeight: 'bold',
                            width: '20px',
                            height: '20px',
                            borderRadius: '50%',
                            backgroundColor: 'white',
                            color: 'black',
                            display: 'flex',
                            alignItems: 'center',
                            justifyContent: 'center',
                            margin: '5px auto 0',
                            cursor: 'pointer'
                        }}
                            onClick={(e) => {
                                e.stopPropagation();
                                setExpanded(!expanded);
                            }}
                        >
                            {expanded ? "-" : "+"}
                        </div>
                    )}
                </div>
                {hasChildren && (
                    <div className={`collapsible-wrapper ${expanded ? 'expanded' : 'collapsed'}`}>
                        <ul>
                            {node.children.map((child) => (
                                <RecursiveTree key={child.Cod_Entite} node={child} />
                            ))}
                        </ul>
                    </div>
                )}
            </li>
        );
    };

    if (loading) return <Loading />;

    return (
        <div className="organigramme-container">
            <Box sx={{ minWidth: '100%', width: 'max-content', padding: '100px', display: 'flex', flexDirection: 'column', alignItems: 'flex-start' }}>
                <Typography variant="h4" sx={{ mb: 4, color: colorBase.colorBase01, fontWeight: 'bold' }}>
                    Organigramme
                </Typography>

                <div className="tree" ref={treeRef} style={{ left: window.innerWidth < 768 ? '3px' : '30px' }}>
                    {treeData ? (
                        <ul>
                            <RecursiveTree node={treeData} />
                        </ul>
                    ) : (
                        <Typography>Aucune donnée disponible</Typography>
                    )}
                </div>
            </Box>
            <Modal
                open={!!selectedPhoto}
                onClose={() => setSelectedPhoto(null)}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
                sx={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }}
            >
                <Box sx={{ outline: 'none', p: 0, bgcolor: 'transparent' }}>
                    {selectedPhoto && (
                        <img
                            src={selectedPhoto}
                            alt="Manager"
                            style={{ maxWidth: '90vw', maxHeight: '90vh', borderRadius: '8px', boxShadow: '0 4px 20px rgba(0,0,0,0.5)' }}
                        />
                    )}
                </Box>
            </Modal>
        </div>
    );
};

export default Organigramme;
