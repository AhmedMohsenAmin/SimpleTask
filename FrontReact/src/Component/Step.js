import React from 'react';
import '../Style/step.css';

const Step = (props) => {
    return (
        <div id="pointer">
            <div style={{...styles.textContainer,color: props.active ? 'yellow' : 'white'}}>
                <p onClick={props.onClick} style={{cursor: 'pointer'}}> {props.text}</p>
                {props.children}
            </div>
        </div>
    )
}


export default Step;

const styles = {
    textContainer:{
        display:'flex', 
        height: '40px', 
        justifyContent:'center', 
        alignItems:'center',
        marginLeft:'15px'
    }
}
