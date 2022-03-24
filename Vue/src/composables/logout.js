//import { ref, onMounted, onUnmounted } from 'vue'

// by convention, composable function names start with "use"
export function logout() {
    let token= localStorage.getItem('token');
    if(!token) return false;
    localStorage.removeItem("token");
    return true;
}