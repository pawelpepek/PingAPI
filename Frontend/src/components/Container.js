import useListen from "../hooks/use-listen"
import DataList from "./DataList"
import LoginButton from "./LoginButton"

import classes from "./Container.module.css"

function Container() {
	const [running, data, onStart, onClose] = useListen()

	return (
		<div className={classes.container}>
			<LoginButton onStart={onStart} close={onClose} running={running} />
			<DataList data={data} />
		</div>
	)
}

export default Container
