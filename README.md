# otthonberles-miklos
A projekt az ingatlan bérlés köré épül. A desktop c# nyelven íródott és magában foglalja a backend részt. A web vue.js javascript keretrendszerben íródott, a hozzá tartozó backend egy Node.js express keretrendszer, ennek segítségével tud kapcsolódni a desktop által generált MySQL adatbázishoz a weboldal.  

Mindkét projekthez szükséges:
XAMPP:
MySQL Database 
Apache Web Server

Desktop indítás:
fejlesztői környezet: Visual Studio
legújabb MySql.Data letöltése a NuGet Package Managerből
properties -> multiple startup projects (az action minden részén startra állítani)
ezután a start gombbal indítható az applikáció

Web indítása: 
fejlesztői környezet: Visual Studio code
frontend:
npm i vue@latest
npm i
npm i bootstrap axios pinia
npm i -D sass
npm i –save @fortawesome/fontawesome-free
npm i @fortawesome/free-solid-svg-icons
npm i vue-router
code .
npm run dev

backend: 
npm init -y
npm i express nodemon mysql2 cors
code .
npx nodemon
(ha az adott számítógépen foglalt a megadott 3000 PORT hibát fog adni a szerver, vagy fel kell szabadítani a PORT-ot vagy át kell írni (backend-index.js; frontend-Login.vue, Profile.vue, Properties.vue, Register.vue))
