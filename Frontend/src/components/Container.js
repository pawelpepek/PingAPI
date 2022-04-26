import useListen from "../hooks/use-listen"
import useClose from "../hooks/use-close"
import { socketClose } from "../hooks/socketClose"
import DataList from "./DataList"

import classes from "./Container.module.css"

function Container() {
	const [login, data, onStart] = useListen()
	useClose()

	const buttonText = login ? "Wyloguj" : "Zaloguj"
	const classButton = `${classes.button} ${login && classes["button-on"]}`

	return (
		<div className={classes.container}>
			<button className={classButton} onClick={login ? socketClose : onStart}>
				{buttonText}
			</button>
			<DataList data={data} />
		</div>
	)
}

export default Container
