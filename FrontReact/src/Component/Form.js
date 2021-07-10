import React from 'react';
import '../Style/item.css';
import '../Style/form.css';

const Form = (props) => {
    return (
        <div>
            <div id="rectangle">
                <div className="cnt">
                    <p>Add/Edit</p>
                </div>
            </div>
            <hr></hr>
            <form className='form-inline'>
                <div>
                    <label>Title</label>
                    <input type='text'></input>
                    <label>Description</label>
                    <input type='text'></input>
                </div>

                <button type='submit'>Save</button>
            </form>
        </div>

    )
}


export default Form;