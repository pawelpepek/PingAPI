import { useEffect } from "react"
import {socketClose} from "./socketClose"

const useClose = () => {
	useEffect(()=>{
		window.addEventListener("beforeunload", function(e) {
			socketClose()
		  });
	},[])
}

export default useClose
