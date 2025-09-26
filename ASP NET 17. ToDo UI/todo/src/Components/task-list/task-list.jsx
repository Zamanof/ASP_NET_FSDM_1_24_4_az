import "./task-list.css"
import TaskListItem from "../task-list-item/task-list-item.jsx";
import PropTypes from "prop-types"
const TaskList = ({ tasks, onDeleted, onChecked }) => {
    return (
        <ul className="list-group list-todo">
            {tasks.map(({ id, ...itemProps }) => (
                <li key={id} className="list-group-item">
                    <TaskListItem
                        {...itemProps}
                        onDeleted={() => onDeleted(id)}
                        onChecked={(isComplete) => onChecked(id, isComplete)}
                    />
                </li>
            ))}
        </ul>
    );
};
TaskList.propTypes = {
    tasks: PropTypes.array.isRequired,
    onDeleted: PropTypes.func.isRequired,
    onChecked: PropTypes.func.isRequired
}
export default TaskList