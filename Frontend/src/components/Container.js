import useListen from "../hooks/use-listen"
import useClose from "../hooks/use-close"
import DataList from "./DataList"
import LoginButton from "./LoginButton"

import classes from "./Container.module.css"

function Container() {
	const [login, data, onStart] = useListen()
	useClose()

	return (
		<div className={classes.container}>
			<LoginButton onStart={onStart} login={login} />
			<DataList data={data} />
		</div>
	)
}

export default Container
