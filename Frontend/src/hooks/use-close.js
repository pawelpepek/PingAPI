import { useEffect } from "react"
import {socketClose} from "./socketClose"

const useClose = (token) => {
	useEffect(()=>{
		window.addEventListener("beforeunload", function(e) {
			socketClose(token)
		  });
	},[token])
}


export default useClose
