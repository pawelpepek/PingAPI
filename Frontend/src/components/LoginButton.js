import { socketClose } from "../hooks/socketClose"
import classes from "./LoginButton.module.css"

const LoginButton = props => {
	const buttonText = props.login ? "Wyloguj" : "Zaloguj"
	const classButton = `${classes.button} ${props.login && classes["button-on"]}`

	return (
		<button
			className={classButton}
			onClick={props.login ? socketClose : props.onStart}>
			{buttonText}
		</button>
	)
}

export default LoginButton
