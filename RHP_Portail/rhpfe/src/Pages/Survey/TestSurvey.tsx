import React from 'react'
import UdValeurUnique from './Components/UdValeurUnique'

const TestSurvey = () => {
  return (
    <div
    style={{width: '100vw', height: '100vh', backgroundColor: 'red' }}>
        <div style={{width: '60vw', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', margin: 'auto', backgroundColor: 'white', padding: '20px'}}>
        <h1>Test Survey Page</h1>
        <br/>
        <UdValeurUnique Obligatoire={true} 
    Typ_Reponse="numerique" numQuestion="1" laquestion="Ceci est une question test"
    avecNote={false} modeScoring="auto" coef={1} maxScore={1} colonnes='' funcScoring='' noteManuelle={1} />
     <UdValeurUnique Obligatoire={true} 
    Typ_Reponse="alpha" numQuestion="2" laquestion="Qu'en pensez vous ?"
    avecNote={false} modeScoring="auto" coef={1} maxScore={1} colonnes='' funcScoring='' noteManuelle={1} />
    <UdValeurUnique Obligatoire={true} 
    Typ_Reponse="date" numQuestion="3" laquestion="En quelle date pensez-vous ?"
    avecNote={false} modeScoring="auto" coef={1} maxScore={1} colonnes='' funcScoring='' noteManuelle={1} />
    <UdValeurUnique Obligatoire={true} 
    Typ_Reponse="liste" numQuestion="4" laquestion="Choisissez une réponse parmi la liste"
    avecNote={false} modeScoring="auto" coef={1} maxScore={1} colonnes='Options 01;Options 02;Options 03' funcScoring='' noteManuelle={1} />
    
    </div>
    </div>
  )
}

export default TestSurvey