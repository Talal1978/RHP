import React from 'react'
import UdValeurUnique from './Components/UdValeurUnique'
import UdGrilleCases from './Components/UdGrilleCases'
import { colorBase } from '../../modules/module_general'
import UdGrilleChoix from './Components/UdGrilleChoix'
import UdGrilleLibre from './Components/UdGrilleLibre'

const TestSurvey = ({avecNote}: {avecNote:boolean}) => {
  return (
    <div style={{ width: '100vw', minHeight: '100vh', backgroundColor: '#eef2f6', overflowY: 'auto' }}>
      <div style={{
        maxWidth: '1200px',
        width: '95%',
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'stretch',
        justifyContent: 'flex-start',
        margin: '20px auto',
        backgroundColor: 'white',
        padding: '30px',
        borderRadius: '8px',
        boxShadow: '0 4px 12px rgba(0,0,0,0.1)'
      }}>
        <h1 style={{ color: colorBase.colorBase01, marginBottom: '20px', borderBottom: `2px solid ${colorBase.colorBase02}`, paddingBottom: '10px' }}>
            Questionnaire de Satisfaction
        </h1>
        
        {/* On passe "avecNote" à tout le monde pour l'alignement global */}
        
        <UdValeurUnique Obligatoire={true}
          Typ_Reponse="numerique" numQuestion={1} laquestion="Veuillez saisir votre code agent :"
          avecNote={avecNote} note={{ coef: 1, note_totale: 1, note: 1}} colonnes='' funcScoring=''  />

        <UdValeurUnique Obligatoire={true}
          Typ_Reponse="alpha" numQuestion={2} laquestion="Quel est votre poste actuel ?"
          avecNote={avecNote} note={{ coef: 1, note_totale: 1, note: 1}} colonnes='' funcScoring=''  />

        <UdValeurUnique Obligatoire={true}
          Typ_Reponse="date" numQuestion={3} laquestion="Quelle est la date de l'incident ?"
          avecNote={avecNote} note={{ coef: 1, note_totale: 1, note: 1}} colonnes='' funcScoring=''  />

        <UdValeurUnique Obligatoire={true}
          Typ_Reponse="liste" numQuestion={4} laquestion="Choisissez un département :"
          avecNote={avecNote} note={{ coef: 1, note_totale: 1, note: 1}} colonnes='Informatique;Ressources Humaines;Comptabilité;Logistique' funcScoring='' />

        <UdValeurUnique Obligatoire={true} funcScoring='' colonnes=''
          Typ_Reponse="multiLine" numQuestion={5} laquestion="Justifiez votre choix en quelques lignes :"
          avecNote={avecNote} note={{ coef: 1, note_totale: 1, note: 1}} />

        <UdGrilleCases Obligatoire={true} avecNote={avecNote}
          numQuestion={6} laquestion="Sur une échelle, comment évalueriez-vous les aspects suivants ?"
colonnes='Faible;Moyen;Bon;Excellent' 
          lignes='Qualité du service;Réactivité;Amabilité;Propreté' note={{ coef: 1, note_totale: 1, note: 1}}
         />
          <UdGrilleChoix Obligatoire={false}
          numQuestion={7} laquestion="Choisissez votre(s) option(s) préférée(s) :"
          avecNote={avecNote}   note={{ coef: 1, note_totale: 1, note: 1}}
          colonnes='Option A;Option B;Option C;Option D' 
          lignes='Choix1;Choix2;Choix3;Choix4' 
/>
          <UdGrilleLibre Obligatoire={false}
          numQuestion={8} laquestion="Veuillez fournir vos commentaires supplémentaires :"
          avecNote={avecNote}    note={{ coef: 1, note_totale: 1, note: 1}}
          colonnes='Objectif[T];Atteint[O];Note[N];Date max[D]' 
          lignes={3}
   />
      </div>
    </div>
  )
}

export default TestSurvey