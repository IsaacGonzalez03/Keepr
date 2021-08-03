import{r as a,c as t,y as e,p as s,e as l,z as c,d as n,o,a as d,b as r,t as u,j as i,F as p,i as w,w as f,f as v}from"./vendor.a3a08785.js";import{p as m,v as y,k as g,P as k,A as h}from"./index.64c953f8.js";const K={name:"ProfilePage",setup(){const s=c(),l=a({profile:t((()=>h.activeProfile)),vaults:t((()=>h.vaults)),account:t((()=>h.account)),accountVaults:t((()=>h.accountVaults)),accountKeeps:t((()=>h.accountKeeps)),keeps:t((()=>h.keeps)),newVault:{},newKeep:{},loading:!0});return e((async()=>{try{await m.getById(s.params.id),await y.getVaultsByProfileId(s.params.id),await g.getKeepsByProfileId(s.params.id),l.loading=!1}catch(a){k.toast("error")}})),{state:l,async newVault(){try{l.newVault.creatorId=l.account.id,await y.create(l.newVault),k.toast("success")}catch(a){k.toast("error")}},async newKeep(){try{l.newKeep.creatorId=l.account.id,await g.create(l.newKeep),window.alert("created")}catch(a){window.alert("failed")}}}}},V=f();s("data-v-1c1f2726");const b={key:0},x={key:1,class:"container-fluid"},I={class:"row p-sm-5 p-2"},P={class:"col-sm-3 card bg-none"},M={class:"col-2"},j={key:0,title:"add vault",type:"button",class:"btn btn-primary","data-toggle":"modal","data-target":"#exampleModal","data-whatever":"@mdo"},B=v(" Vault "),N=r("i",{class:"fas fa-plus text-success text-shadow"},null,-1),_=r("hr",null,null,-1),z={key:1,title:"add keep",type:"button",class:"btn btn-primary","data-toggle":"modal","data-target":"#keepModal","data-whatever":"@mdo"},A=v(" Keep "),F=r("i",{class:"fas fa-plus text-success text-shadow"},null,-1),L={class:"row"},q={class:"col-12"},C=r("h1",null,"Vaults",-1),D=r("hr",null,null,-1),E={class:"card-columns"},G={class:"col-12"},H=r("h1",null,"Keeps",-1),J=r("hr",null,null,-1),O={class:"card-columns"};l();const Q=V(((a,t,e,s,l,c)=>{const f=n("Vault"),v=n("Keep"),m=n("NewKeepModal"),y=n("NewVaultModal");return o(),d(p,null,[!0!==s.state.loading||s.state.profile?(o(),d("div",x,[r("div",I,[r("div",P,[r("img",{src:s.state.profile.picture,alt:"profile pic",class:"bg-none"},null,8,["src"])]),r("div",M,[r("p",null,u(s.state.profile.name),1),r("p",null,"Vaults: "+u(s.state.vaults.length),1),s.state.account.id==s.state.profile.id?(o(),d("button",j,[B,N])):i("",!0),_,r("p",null,"Keeps: "+u(s.state.keeps.length),1),s.state.account.id==s.state.profile.id?(o(),d("button",z,[A,F])):i("",!0)]),r("div",L,[r("div",q,[C,D,r("div",E,[(o(!0),d(p,null,w(s.state.vaults,(a=>(o(),d(f,{key:a.id,vault:a},null,8,["vault"])))),128))])]),r("div",G,[H,J,r("div",O,[(o(!0),d(p,null,w(s.state.keeps,(a=>(o(),d(v,{key:a.id,keep:a},null,8,["keep"])))),128))])])])])])):(o(),d("div",b," ...Loading ")),r(m),r(y)],64)}));K.render=Q,K.__scopeId="data-v-1c1f2726";export default K;
