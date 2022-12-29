import classes from "./LoginButton.module.css"

const LoginButton = props => {
	const buttonText = props.running ? "Wyloguj" : "Zaloguj"
	const classButton = `${classes.button} ${
		props.running && classes["button-on"]
	}`

	return (
		<button
			className={classButton}
			onClick={props.running ? props.close : props.onStart}>
			{buttonText}
		</button>
	)
}

export default LoginButton
