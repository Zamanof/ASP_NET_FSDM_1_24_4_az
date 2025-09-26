import "./item-add.css"
import {useState} from "react";
import PropTypes from "prop-types";
const ItemAdd = ({onAdded}) => {
    const [text, setText] = useState("")

    const onTextChanged=(e)=>{
        setText(e.target.value)
    }
    const onSubmit = (e)=>{
        e.preventDefault()
        if(text.trim()){
            onAdded(text);
            setText('')
        }
    }
    return(
        <form className={"d-flex item-add"} onSubmit={onSubmit}>
            <input
            type={"text"}
            className={"form-control"}
            onChange={onTextChanged}
            value={text}/>
            <button
                className={"btn btn-outline-secondary"}>
                Add Item
            </button>
        </form>


    )
}
ItemAdd.propTypes = {
    onAdded: PropTypes.func.isRequired,
};
export default ItemAdd