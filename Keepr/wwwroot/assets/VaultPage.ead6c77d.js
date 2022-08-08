import{x as f,f as d,u as y,o as V,g,h as l,i as r,j as a,t as p,y as h,F as k,z as w,k as x}from"./vendor.98d396ec.js";import{_ as b,v as _,a as K,P as m,A as c}from"./index.36cdd5e0.js";const P={setup(){let s=f(),n=d(()=>c.activeVaultKeeps),i=d(()=>c.activeVault),e=d(()=>c.account),o=y();return V(async()=>{let t=await _.getVault(s.params.id);!t&&(t==null?void 0:t.creatorId)!=e.id&&o.push({name:"Home"}),await K.getVaultKeeps(s.params.id)}),{keeps:n,vault:i,account:e,router:o,route:s,async deleteVault(t){await m.confirm("Are you sure you want to delete the vault?","This cannot be undone","warning")&&(await _.deleteVault(t),o.push({name:"Profile",params:{id:c.account.id}}),m.toast("Vault Deleted","success"))}}}},j={class:"container"},S={class:"d-flex justify-content-between"},A={class:"mt-4"},B={class:"masonry-frame mt-5"};function C(s,n,i,e,o,t){const v=g("Keep");return l(),r("div",j,[a("div",S,[a("div",A,[a("h1",null,p(e.vault.name),1),a("p",null,"Keeps: "+p(e.keeps.length),1)]),e.account.id==e.vault.creatorId?(l(),r("button",{key:0,class:"btn btn-outline-danger mt-3",onClick:n[0]||(n[0]=u=>e.deleteVault(e.vault.id))},"delete vault")):h("",!0)]),a("div",B,[(l(!0),r(k,null,w(e.keeps,u=>(l(),r("div",{key:u.id},[x(v,{keep:u,class:"my-3"},null,8,["keep"])]))),128))])])}var D=b(P,[["render",C],["__scopeId","data-v-30912b6d"]]);export{D as default};
