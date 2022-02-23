using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class AccesoWEB: MonoBehaviour
{
    //Variables para el formulario
    private Button boton;
    private InputField inputUsuario, inputClave;
    private Text textoError;
    
    //Rutas de acceso a la API
    string urlAccesoDb = "http://157.230.102.160/produccion/apiunity/accesodb.php&quot";

    //Variable pública Usuario (para poder acceder desde otros scripts)
    public Usuario usuario;
    
    // Start is called before the first frame update
    void Start()
    {
        //Evito que se destruya el objeto entre escenas (para poder acceder a sus variables públicas después)
        DontDestroyOnLoad(this);
        
        //Capturo el componente Button del objeto llamado Botón
        boton = GameObject.Find("Boton Jugar").GetComponent<Button>();
        
        //Acción onclick
        boton.onClick.AddListener(() => Acceder());
        
        //Capturo la caja de texto de error y la desactivo
        textoError = GameObject.Find("Error").GetComponent<Text>();
        textoError.enabled = false;

    }

    void Acceder()
    {
        //Capturo los inputField del formulario
        inputUsuario = GameObject.Find("Usuario").GetComponent<InputField>();
        inputClave = GameObject.Find("Contraseña").GetComponent<InputField>();
        
        //Inicializo objeto Usuario
        usuario = new Usuario(inputUsuario.text,inputClave.text);
        
        //Ejemplo probar acceso con POST y con base de datos
        StartCoroutine(ComprobarAcceso(usuario, urlAccesoDb));
    }

    IEnumerator ComprobarAcceso(Usuario usuario, string urlAcceso)
    {
       
        WWWForm form = new WWWForm();
        form.AddField("usuario", usuario.usuario);
        form.AddField("clave", usuario.clave);

        using (UnityWebRequest www = UnityWebRequest.Post(urlAcceso, form))
        {
            yield return www.SendWebRequest();
            
            //Compruebo acceso o muestro mensaje de error
            if (www.downloadHandler.text == "1")
            {
                //Cargo la escena de juego
                Debug.Log("Acceso correcto");
                SceneManager.LoadScene("Juego");
            }
            else
            {
                //Muestro mensaje de error
                Debug.Log(www.error);
                Debug.Log("Acceso denegado");
                textoError.enabled = true;
            }
        }
    }
}