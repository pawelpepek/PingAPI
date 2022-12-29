export const socketClose = (token) => {
	new WebSocket("ws://localhost:5000/logout/"+token)
}