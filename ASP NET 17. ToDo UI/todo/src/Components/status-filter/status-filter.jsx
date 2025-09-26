import './status-filter.css'
import PropTypes from "prop-types";
const StatusFilter=({active, text})=>{
    const clazz = active
        ? "btn btn-info btn-outline-secondary"
        : "btn btn-outline-secondary"
    return (
        <button type={"button"} className={clazz}>
            {text}
        </button>
    )
}

StatusFilter.propTypes = {
    active: PropTypes.bool.isRequired,
    text: PropTypes.string.isRequired,
}

export default StatusFilter