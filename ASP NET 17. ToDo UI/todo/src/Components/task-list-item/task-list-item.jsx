import "./task-list-item.css"
import {useEffect, useState} from "react";
import PropTypes from "prop-types";
const TaskListItem = ({text, isCompleted, onChecked, onDeleted}) => {

    const [isComplete, setIsComplete] = useState(false)

    useEffect(() => {
        setIsComplete(isCompleted)
    }, [isCompleted]);

    const onClickText = ()=>{
        const newStatus = !isCompleted;
        setIsComplete(newStatus);
        onChecked(newStatus)
    }
    const itemStyle = {
        textDecoration: isComplete? "line-through":"none"
    }

    return(
        <span className={"todo-list-item"}>
            <span className={"todo-list-item-text"}
                  style={itemStyle}
            onClick={onClickText}>
                {text}
            </span>
            <button
            type={"button"}
            className={"btn btn-outline-danger btn-sm delete"}
            onClick={onDeleted}>
                Delete
            </button>
        </span>

    )
}
TaskListItem.propTypes = {
    text: PropTypes.string.isRequired,
    isCompleted: PropTypes.bool.isRequired,
    onChecked: PropTypes.func.isRequired,
    onDeleted: PropTypes.func.isRequired

}
export default TaskListItem