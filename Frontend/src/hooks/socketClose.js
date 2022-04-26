export const socketClose = () => {
	new WebSocket("ws://localhost:5000/logout")
}
