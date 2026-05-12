import { useEffect, useState, useContext } from "react";
import { useParams, useNavigate } from "react-router-dom";
import GroupBox from "../../components/GroupBox/GroupBox";
import { Box, Typography, Chip, Divider, Paper, Stack, IconButton } from "@mui/material";
import useAxiosPost from "../../hooks/useAxiosPost";
import { cntX } from "../../Menu/MenuMain";
import Bouton from "../../components/Bouton/Bouton";
import { colorBase } from "../../modules/module_general";
import { ReplyOutlined } from "@mui/icons-material";

const Communication_Blog = () => {
    const { num } = useParams(); // Capture the ID (Num_Blog) from route :num
    const navigate = useNavigate();
    const myAxios = useAxiosPost();
    const { isSmall } = useContext(cntX);
    const [blog, setBlog] = useState<any>(null);

    useEffect(() => {
        if (num) {
            myAxios("get_communication_blog", { Num_Blog: num })
                .then((dt) => {
                    if (dt.data && dt.data.result && dt.data.data.length > 0) {
                        setBlog(dt.data.data[0]);
                    }
                })
                .catch((err) => console.error(err));
        }
    }, [num]);

    if (!blog) return <div>Chargement...</div>;

    return (
        <GroupBox
            label={`Blog: ${blog.Num_Blog}`}
            showBorders={!isSmall}
            showTitre={true}
            sx={{
                padding: "20px",
                maxWidth: "1200px",
                margin: "auto",
                height: "100%",
                display: "flex",
                flexDirection: "column"
            }}
        >
            <Box sx={{ mb: 2, flexGrow: 1, overflow: "auto" }}>
                <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                    <Stack direction="row" spacing={1} alignItems="center">
                        <IconButton onClick={() => navigate(-1)} color="primary">
                            <ReplyOutlined />
                        </IconButton>
                        <Stack>
                            <Typography variant="h5" sx={{ fontWeight: 'bold', color: colorBase.colorBase01 }}>
                                {blog.Titre_Blog}
                            </Typography>
                            <Stack direction="row" spacing={1}>
                                {blog.Categorie && <Chip label={blog.Categorie} size="small" color="primary" variant="outlined" />}
                                {blog.Tags && blog.Tags.split(/[;,]/).map((tag: any, idx: number) => (
                                    tag.trim() && <Chip key={idx} label={`#${tag.trim()}`} size="small" />
                                ))}
                            </Stack>
                        </Stack>
                    </Stack>
                </Box>

                <Typography variant="caption" color="textSecondary" sx={{ mb: 2, display: 'block', mt: 1 }}>
                    Publié le {new Date(blog.Dat_Crea).toLocaleDateString()} par {blog.Created_by}
                </Typography>

                <Divider sx={{ my: 2 }} />

                <Paper elevation={0} sx={{ p: 2, bgcolor: 'background.paper' }}>
                    <div
                        dangerouslySetInnerHTML={{ __html: blog.Contenus }}
                        style={{ lineHeight: '1.6', overflowWrap: 'break-word', maxWidth: '100%' }}
                    />
                </Paper>
            </Box>
        </GroupBox>
    );
};

export default Communication_Blog;
