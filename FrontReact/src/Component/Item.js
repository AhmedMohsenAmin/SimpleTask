import React,{useEffect, useState} from 'react';
import '../Style/item.css';

const ItemList = ({stepItems=[], removeItem=() => {}}) => {
    const [currentItem, setCurrentItem] = useState(stepItems[0])
    useEffect(() => {
        setCurrentItem(stepItems[0])
    }, [stepItems])


    return (
        <div style={{border: '1px solid green', width: '50%', margin: '0 auto'}}>
           
           {
               stepItems.map(item =>
                <div key={item.order}>
                    <div id="rectangle">
                        <h4
                        onClick={() => setCurrentItem(item)} 
                        style={{cursor: 'pointer',color: currentItem.order === item.order ? 'yellow' : 'white'}}>
                            {`Item ${item.order}`}
                            <a onClick={() => removeItem(item.order)} 
                                style={{cursor:'pointer', color: 'white', margin:'10px'}}
                            >
                                -
                            </a>    
                        </h4>
                    </div>
                    
                    <hr></hr>
                    
                    <ul>
                        <li>{item.title}</li>
                        <li>{item.description}</li>
                    </ul>
                </div>
                )
           }
        </div>

    )
}


export default ItemList;