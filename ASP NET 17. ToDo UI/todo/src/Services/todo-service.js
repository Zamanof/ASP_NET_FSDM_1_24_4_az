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
            localStorage.setItem("accessToken", result.token)
        })
            .catch((error)=>{
                console.log(error);
            });
        return statusCode;
    }

    login = async (e, email, password) => {
        let statusCode;
        e.preventDefault();
        await fetch(`${this._base}/Auth/login`,
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
            localStorage.setItem('accessToken', result.token)
        }).catch((error)=>{
            console.log(error);
        });
        return statusCode;
    }

    async AddItem(text){
        return await fetch(`${this._base}/ToDo`,{
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("accessToken")}`
            },
            body: JSON.stringify({text: text})
        })
    }

    async getAll(){
        const resource = await fetch(`${this._base}/ToDo/?page=1&pageSize=100`,{
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("accessToken")}`
            }
        })
        const result = await resource.json()
        console.log(result.items)
        return result.items
    }

    changeStatus(id, status){
        fetch(`${this._base}/ToDo/${id}/status`,{
            method: "PATCH",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("accessToken")}`
            },
            body: status
        })
    }
}
export default TodoService