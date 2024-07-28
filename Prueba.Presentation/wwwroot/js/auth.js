export function SignIn(user, password, redirect) {

    var url = "/api/auth/signin";
    var xhr = new XMLHttpRequest();

    // Initialization
    xhr.open("POST", url);
    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    // Catch response
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) // 4=DONE 
        {
            console.log("Call '" + url + "'. Status " + xhr.status);
            if (redirect)
                location.replace(redirect);
        }
    };

    // Data to send
    var data = {
        user: user,
        password: password
    };

    // Call API
    xhr.send(JSON.stringify(data));
}

export function SignOut(redirect) {

    var url = "/api/auth/signout";
    var xhr = new XMLHttpRequest();

    // Initialization
    xhr.open("POST", url);
    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    // Catch response
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) // 4=DONE 
        {
            console.log("Call '" + url + "'. Status " + xhr.status);
            if (redirect)
                location.replace(redirect);
        }
    };

    // Call API
    xhr.send();
}

async function GetClaims() {
    const url = "/api/auth/getclaims";

    try {
        const response = await fetch(url, {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify({})
        })
        if (response.status == 200) {
            const data = await response.json();
            return data;
        }
        //.then(response => {
        //    if (response.status === 200) {
        //        return response.json();
        //    }
        //});
    } catch (error) {
        console.error("Error occurred:", error);
    }
}