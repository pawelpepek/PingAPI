import { useState, useEffect } from "react"
import { socketClose } from "./socketClose"

const useListen = () => {
	const [token, setToken] = useState("")

	const [listenClient, setListeClient] = useState()

	const [data, setData] = useState([])

	const onLoginHandler = () => {
		setListeClient(new WebSocket("ws://localhost:5000/listen"))
	}

	useEffect(() => {
		if (listenClient !== undefined) {
			listenClient.onmessage = async message => {
				const text = await message.data.text()
				if (text.startsWith("token:")) {
					setToken(text.substring(6))
				} else {
					setData(last => [text, ...last].slice(0, 5))
				}
			}
			listenClient.onclose = () => {
				socketClose(token)
				setToken("")
			}
			listenClient.onerror = err => {
				console.log("Błąd ", err)
			}
		}
	}, [listenClient])

	return [token, data, onLoginHandler]
}

export default useListen
