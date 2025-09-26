import App from "../Components/app/App.jsx";

class TodoService{
    _base = 'http://localhost:5107/api'

    register = async (e, email, password) => {
        let statusCode;
        e.preventDefault();
        await fetch(`${this._base}/Auth/register`,
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                credentials: "include",
                body: JSON.stringify({
                    email: email,
                    password: password
                })
            }).then((response)=>{
            if (response.status !== 200) throw (response.status)
            statusCode = response.status;
            return response.json();
        }).then((result)=>{
            localStorage.setItem("accessToken", result.accessToken)
        })
            .catch((error)=>{
                console.log(error);
            });
        return statusCode;
    }

    login = async (e, email, password) => {
        let statusCode;
        e.preventDefault();
        await fetch(`${this._base}/Auth/register`,
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                credentials: "include",
                body: JSON.stringify({
                    email: email,
                    password: password
                })
            }).then((response)=>{
            if (response.status !== 200) throw (response.status)
            statusCode = response.status;
            return response.json();
        }).then(result=>{
            localStorage.setItem('accessToken', result.accessToken)
        }).catch((error)=>{
            console.log(error);
        });
        return statusCode;
    }
}
export default TodoService