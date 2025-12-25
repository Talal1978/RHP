import React, { useEffect, useState } from 'react';
import useAxiosPost from '../../hooks/useAxiosPost';
import { Card, CardContent, Typography, Grid, Box, Grow } from '@mui/material';
import { Description as DescriptionIcon } from '@mui/icons-material';
import { colorBase } from '../../modules/module_general';

interface IEdition {
    Cod_Report: string;
    Nom_Report: string;
    Description: string;
}

const DiverseEditions = () => {
    const myAxios = useAxiosPost();
    const [editions, setEditions] = useState<IEdition[]>([]);

    useEffect(() => {
        myAxios("get_diverse_editions", {})
            .then(res => {
                if (res.data.result) {
                    setEditions(res.data.data);
                }
            });
    }, []);

    const handleCardClick = (report: IEdition) => {
        // Placeholder for clicking logic, e.g., opening a report viewer
        // For now, just logging or showing alert if needed, but user didn't specify action yet.
        console.log("Clicked:", report.Cod_Report);
        // Assuming generation logic would be something like:
        // myAxios("getreport", { report: report.Cod_Report }); 
        // But for now just the list as requested.
    };

    return (
        <Box sx={{ p: 4 }}>
            <Typography variant="h4" gutterBottom sx={{ color: colorBase.colorBase01, mb: 4, fontWeight: 'bold' }}>
                Editions Diverses
            </Typography>
            <Grid container spacing={3}>
                {editions.map((edition, index) => (
                    <Grow in={true} timeout={(index + 1) * 200} key={edition.Cod_Report}>
                        <Grid item xs={12} sm={6} md={4} lg={3}>
                            <Card
                                onClick={() => handleCardClick(edition)}
                                sx={{
                                    cursor: 'pointer',
                                    height: '100%',
                                    display: 'flex',
                                    flexDirection: 'column',
                                    transition: 'transform 0.3s, box-shadow 0.3s',
                                    '&:hover': {
                                        transform: 'translateY(-5px)',
                                        boxShadow: '0 8px 16px rgba(0,0,0,0.2)',
                                        borderColor: colorBase.colorBase02
                                    },
                                    border: '1px solid transparent',
                                    // Glassmorphism effect hint
                                    backdropFilter: 'blur(10px)',
                                    backgroundColor: 'rgba(255, 255, 255, 0.9)',
                                }}
                            >
                                <CardContent sx={{ flexGrow: 1, display: 'flex', flexDirection: 'column', alignItems: 'center', textAlign: 'center' }}>
                                    <Box sx={{
                                        mb: 2,
                                        p: 2,
                                        borderRadius: '50%',
                                        backgroundColor: colorBase.colorBase04 + '20', // transparent tint
                                        color: colorBase.colorBase01
                                    }}>
                                        <DescriptionIcon fontSize="large" />
                                    </Box>
                                    <Typography variant="h6" component="div" sx={{ fontWeight: 'bold', mb: 1 }}>
                                        {edition.Nom_Report}
                                    </Typography>
                                    <Typography variant="body2" color="text.secondary">
                                        {edition.Description || "Aucune description disponible"}
                                    </Typography>
                                </CardContent>
                            </Card>
                        </Grid>
                    </Grow>
                ))}
            </Grid>
        </Box>
    );
};

export default DiverseEditions;
