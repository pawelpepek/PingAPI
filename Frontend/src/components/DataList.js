import classes from "./DataList.module.css"

const DataList = props => {
    const getLine = (text, i) => <li key={i}>{text}</li>

	return <ul className={classes.list}>{props.data.map((d, i) => getLine(d, i))}</ul>
}

export default DataList
