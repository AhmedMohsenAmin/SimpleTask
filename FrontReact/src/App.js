import './App.css';
import Step from './Component/Step';
import ItemList from './Component/Item';
import Form from './Component/Form';
import './Style/form.css';
import ReactDOM from 'react-dom';
import React, { useState,useEffect } from 'react';


function App() {
  // const [steps, setSteps] = useState([1,2,3])
  const [steps, setSteps] = useState(stepsData);
  const [currentStep, setCurrentStep] = useState(stepsData[0])
  
  const [stepsAPI, setStepsAPI] = useState([]);

  useEffect(() => {
    async function GetSteps() {

        let [DataSteps] = await Promise.all([
            fetch('http://localhost:54712/api/' + 'Task/GetAllSteps').then(response => response.json()), //get |Steps info           
        ]);

        //debugger;
        setStepsAPI(DataSteps.data);
        
    }

    GetSteps(); 

}, []);

  const addNewStep = () => {
    const stepItem =  {
      id: `s${steps.length + 1}`, 
      order:steps.length + 1,
      listOfItems:[
        {order:1, title:'Title', description:'description'},{order:2, title:'Title', description:'description'},{order:3, title:'Title', description:'description'},
      ]
    };
    setSteps([...steps, stepItem])
  }

  const removeStep = (step) => {
    let remainingSteps = steps.filter(s => s.id !== step.id).map(s => {
      return s.order > step.order ? {...s, order : s.order - 1, id: `s${s.order-1}`}: s
    });
    setSteps(remainingSteps)
  }

  const addNewItem = () => {
    let newItem = {
      order:currentStep.listOfItems.length +1, 
      title:'Title', 
      description:'description'
    };
    let newCurrentStep = {...currentStep, listOfItems:currentStep.listOfItems.concat(newItem)}
    let newSteps = steps.map(step => (step.id === currentStep.id ? {...step, listOfItems:newCurrentStep.listOfItems} :step));
    setSteps(newSteps)
    setCurrentStep(newCurrentStep)
  }

  const removeItemByOrder = (order) => {
    const newListOfItems = currentStep.listOfItems.filter(it => it.order !== order).map(it => {
      return it.order > order  ? {...it, order: it.order - 1} : it
    });
    const newCurrentStep = currentStep
    newCurrentStep.listOfItems = newListOfItems;
    setCurrentStep(newCurrentStep);
    let newSteps = steps.map(step => (step.id === newCurrentStep.id ? {...step, listOfItems:newCurrentStep.listOfItems} :step));
    setSteps(newSteps)
  }

  return (
    <div className="App">
      {
        stepsAPI.map(s => 
          <Step 
            key={s.id} 
            text={s.name`step `} 
            active={currentStep.id === s.id} 
            onClick={() => setCurrentStep(s)} >
            {
              s.order !== 1 && <a
              onClick = {() => removeStep(s)} 
              style={styles.minusBtn}
              > -</a>
            }
          </Step>
        )
      }

      <Step>
        <a onClick={addNewStep} style={styles.minusBtn}>+</a>
      </Step>
      <br></br>
      <button onClick = {addNewItem}>Add new Item</button>
      <ItemList stepItems = {currentStep.listOfItems} removeItem={(order) => removeItemByOrder(order)} />
      <Form></Form>
    </div>
  );
}

export default App;

const styles = {
  minusBtn:{ 
    marginLeft: "5px", 
    width: '15px', 
    cursor: 'pointer'
  }
}

const stepsData = [
  {
    id: 's1', 
    order:1, 
    listOfItems:[
      {order:1, title:'Title', description:'description'},{order:2, title:'Title', description:'description'},{order:3, title:'Title', description:'description'},
    ]
  },
  {
    id: 's2', 
    order:2,
    listOfItems:[
      {order:1, title:'Title', description:'description'},{order:2, title:'Title', description:'description'},{order:3, title:'Title', description:'description'},
    ]
  },
  {
    id: 's3', 
    order:3,
    listOfItems:[
      {order:1, title:'Title', description:'description'},{order:2, title:'Title', description:'description'},{order:3, title:'Title', description:'description'},
    ]
  },
]
