import React from 'react'
import Survey_Rendering from '../Survey/Survey_Rendering'

const Evaluation = () => {
  return (
    <div style={{ padding: '20px' }}>
      <h1>Évaluation</h1>
    <Survey_Rendering cod_survey={'SVY000005'} cod_reply={4071} evalue={''} evaluateur={''} typ_survey={'E'} />
    </div>
  )
}

export default Evaluation