import useListen from "../hooks/use-listen"
import useClose from "../hooks/use-close"
import DataList from "./DataList"
import LoginButton from "./LoginButton"

import classes from "./Container.module.css"

function Container() {
	const [token, data, onStart] = useListen()
	useClose(token)

	return (
		<div className={classes.container}>
			<LoginButton onStart={onStart} token={token} />
			<DataList data={data} />
		</div>
	)
}

export default Container
