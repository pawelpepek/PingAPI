import { socketClose } from "../hooks/socketClose"
import classes from "./LoginButton.module.css"

const LoginButton = props => {
	const buttonText = !!props.token ? "Wyloguj" : "Zaloguj"
	const classButton = `${classes.button} ${
		!!props.token && classes["button-on"]
	}`

	return (
		<button
			className={classButton}
			onClick={
				!!props.token
					? () => {
							socketClose(props.token)
					  }
					: props.onStart
			}>
			{buttonText}
		</button>
	)
}

export default LoginButton
