import { useState, useEffect } from "react"

const useListen = () => {
	const [login, setLogin] = useState(false)

	const [listenClient, setListeClient] = useState()

	const [data, setData] = useState([])

	const onLoginHandler = () => {
		setListeClient(new WebSocket("ws://localhost:5000/listen"))
	}

	useEffect(() => {
		if (listenClient !== undefined) {
			listenClient.onopen = () => {
				setLogin(true)
			}
			listenClient.onmessage = async message => {
				const text = await message.data.text()

				setData(last => [text, ...last].slice(0, 5))
			}
			listenClient.onclose = () => {
				setLogin(false)
			}
			listenClient.onerror=err=>{
				console.log("Błąd ",err)
			}
		}
	}, [listenClient])

	return [login, data, onLoginHandler]
}

export default useListen
