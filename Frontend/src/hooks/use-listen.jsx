import { useState, useEffect } from "react"

const useListen = () => {
	const [running, setRunning] = useState(false)
	const [listenClient, setListeClient] = useState()
	const [data, setData] = useState([])

	const onLoginHandler = () => {
		const socket = new WebSocket("ws://localhost:5000/listen")
		setListeClient(socket)
		setRunning(true)
	}

	const onClose = () => {
		if (!!listenClient && listenClient.OPEN) {
			listenClient.close()
			setRunning(false)
		}
	}

	useEffect(() => {
		if (listenClient !== undefined) {
			listenClient.onmessage = async message => {
				const text = await message.data.text()
				setData(last => [text, ...last].slice(0, 5))
			}
			listenClient.onclose = () => {
				setRunning(false)
			}
			listenClient.onerror = err => {
				console.log("Błąd ", err)
			}
		}
	}, [listenClient])

	return [running, data, onLoginHandler, onClose]
}

export default useListen
