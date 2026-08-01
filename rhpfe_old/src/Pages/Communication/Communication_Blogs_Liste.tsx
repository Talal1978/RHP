import { useContext, useEffect, useState } from "react";
import GroupBox from "../../components/GroupBox/GroupBox";
import { Box, Stack, TextField, InputAdornment, FormControl, InputLabel, Select, MenuItem } from "@mui/material";
import Grille, { TColonneCollection } from "../../components/Grille/Grille";
import { ObjetGenerique } from "../../types";
import { colorBase } from "../../modules/module_general";
import useAxiosPost from "../../hooks/useAxiosPost";
import { useNavigate } from "react-router-dom";
import { cntX } from "../../Menu/MenuMain";
import { Search, FilterList } from "@mui/icons-material";

const Communication_Blogs_Liste = () => {
    const navigate = useNavigate();
    const [ds, setDs] = useState<ObjetGenerique[]>([]);
    const [filteredDs, setFilteredDs] = useState<ObjetGenerique[]>([]);
    const [dsFields, setDsFields] = useState<TColonneCollection>({});
    const [searchText, setSearchText] = useState("");
    const [selectedCategory, setSelectedCategory] = useState("Tous");
    const [categories, setCategories] = useState<string[]>(["Tous"]);
    const { isSmall } = useContext(cntX);
    const myAxios = useAxiosPost();

    useEffect(() => {
        // Define columns
        setDsFields({
            Num_Blog: { columnName: "Num_Blog", headerText: "N° Blog", dataType: "nvarchar", visible: true, readOnly: true, sx: { width: 100 } },
            Titre_Blog: { columnName: "Titre_Blog", headerText: "Titre", dataType: "nvarchar", visible: true, readOnly: true },
            Categorie: { columnName: "Categorie", headerText: "Catégorie", dataType: "nvarchar", visible: true, readOnly: true, sx: { width: 150 } },
            Tags: { columnName: "Tags", headerText: "Tags", dataType: "nvarchar", visible: true, readOnly: true },
            Dat_Crea: { columnName: "Dat_Crea", headerText: "Date Création", dataType: "datetime", visible: true, readOnly: true, sx: { width: 150 } },
            Created_by: { columnName: "Created_by", headerText: "Créé par", dataType: "nvarchar", visible: true, readOnly: true, sx: { width: 150 } },
            Publier: { columnName: "Publier", headerText: "Publié", dataType: "bool", visible: true, readOnly: true, sx: { width: 80 } }
        });

        // Fetch data
        myAxios("communication_blogs_liste", {})
            .then((dt) => {
                if (dt.data && dt.data?.result) {
                    const data = dt.data.data;
                    setDs(data);

                    // Extract unique categories
                    const uniqueCats = Array.from(new Set(data.map((item: any) => item.Categorie || "Non classé"))) as string[];
                    setCategories(["Tous", ...uniqueCats]);
                } else {
                    setDs([]);
                }
            })
            .catch((err) => {
                setDs([]);
            });
    }, []);

    useEffect(() => {
        let res = ds;

        if (searchText) {
            const lowerSearch = searchText.toLowerCase();
            res = res.filter((item: any) =>
                (item.Titre_Blog && item.Titre_Blog.toLowerCase().includes(lowerSearch)) ||
                (item.Tags && item.Tags.toLowerCase().includes(lowerSearch))
            );
        }

        if (selectedCategory !== "Tous") {
            res = res.filter((item: any) => item.Categorie === selectedCategory || (selectedCategory === "Non classé" && !item.Categorie));
        }

        setFilteredDs(res);
    }, [ds, searchText, selectedCategory]);

    return (
        <GroupBox
            label="Blogs"
            showBorders={!isSmall}
            showTitre={true}
            sx={{
                padding: "10px",
                height: "100%",
                display: "flex",
                flexDirection: "column"
            }}
        >
            <Box
                sx={{
                    margin: "auto",
                    padding: "1em",
                    width: "100%",
                    height: "100%",
                    overflow: "auto",
                }}
            >
                <Stack direction={isSmall ? "column" : "row"} spacing={2} sx={{ mb: 2 }}>
                    <TextField
                        label="Rechercher (Titre, Tags)"
                        variant="outlined"
                        size="small"
                        value={searchText}
                        onChange={(e) => setSearchText(e.target.value)}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <Search />
                                </InputAdornment>
                            ),
                        }}
                        sx={{ flexGrow: 1 }}
                    />
                    <FormControl size="small" sx={{ minWidth: 200 }}>
                        <InputLabel>Catégorie</InputLabel>
                        <Select
                            value={selectedCategory}
                            label="Catégorie"
                            onChange={(e) => setSelectedCategory(e.target.value)}
                            startAdornment={
                                <InputAdornment position="start">
                                    <FilterList />
                                </InputAdornment>
                            }
                        >
                            {categories.map((cat) => (
                                <MenuItem key={cat} value={cat}>{cat}</MenuItem>
                            ))}
                        </Select>
                    </FormControl>
                </Stack>

                <Box sx={{ flexGrow: 1, overflow: "auto" }}>
                    <Grille
                        readonly={true}
                        dataSource={filteredDs}
                        Colonnes={dsFields}
                        className="laGrille"
                        onclick={({ colIndex, value }) => {
                            if (colIndex === 0) {
                                // Navigate to detail page
                                navigate(`/myspace/Communication_Blog/Blog/${value}`);
                            }
                        }}
                        sx={{
                            "& .cl0": {
                                width: "100px !important",
                                cursor: "pointer !important",
                                "&:hover": {
                                    color: colorBase.colorBase02,
                                    fontWeight: "bold",
                                    textDecoration: "underline",
                                },
                            },
                        }}
                    />
                </Box>
            </Box>
        </GroupBox>
    );
};

export default Communication_Blogs_Liste;
