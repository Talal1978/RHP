import React, { useEffect, useRef } from 'react'
import { Typography, Paper, Grid, Box } from '@mui/material';
import Survey_Rendering from '../Survey/Survey_Rendering'
import { colorBase } from '../../modules/module_general';
import { useLocation } from 'react-router-dom';
type TState = {
  cod_survey: string;
  cod_evaluation: string;
  lib_evaluation: string;
  cod_reply: number;
  evalue: string;
  nom_evalue: string;
  evaluateur: string;
  nom_evaluateur: string;
  typ_survey: "E";
}
const Evaluation = () => {
  const myRef = useRef(null);
  const location = useLocation();
  const state = location.state as TState;
  const { cod_survey, cod_evaluation, lib_evaluation, cod_reply, evalue, nom_evalue, evaluateur, nom_evaluateur, typ_survey } = state;

  useEffect(() => {
    console.log(state);
  }, [state]);
  return (
    <div style={{ padding: '20px', display: 'flex', flexDirection: 'column', gap: '20px', alignItems: 'center', width: '100%' }}>
      <Typography variant="h4" sx={{ textAlign: 'center', mb: 2, fontWeight: 'bold', color: colorBase.colorBase01 }}>
        Évaluation
      </Typography>

      <Paper elevation={2} sx={{ p: 3, width: '100%', maxWidth: '800px', borderRadius: 2 }}>
        <Grid container spacing={2}>
          <Grid item xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Evaluation
              </Typography>
              <Typography variant="body1">
                {cod_evaluation} {lib_evaluation}
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Évaluateur
              </Typography>
              <Typography variant="body1">
                {evaluateur} {nom_evaluateur}
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Evalué
              </Typography>
              <Typography variant="body1">
                {evalue} {nom_evalue}
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Formulaire
              </Typography>
              <Typography variant="body1">
                {cod_survey}
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Réponses
              </Typography>
              <Typography variant="body1">
                {cod_reply}
              </Typography>
            </Box>
          </Grid>
        </Grid>
      </Paper>
      <Survey_Rendering refChild={myRef} cod_survey={cod_survey} cod_reply={cod_reply} evalue={evalue} evaluateur={evaluateur} typ_survey={typ_survey} />
    </div>
  )
}

export default Evaluation