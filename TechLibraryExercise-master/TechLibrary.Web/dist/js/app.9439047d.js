(function(e){function t(t){for(var n,i,l=t[0],c=t[1],s=t[2],u=0,d=[];u<l.length;u++)i=l[u],Object.prototype.hasOwnProperty.call(o,i)&&o[i]&&d.push(o[i][0]),o[i]=0;for(n in c)Object.prototype.hasOwnProperty.call(c,n)&&(e[n]=c[n]);p&&p(t);while(d.length)d.shift()();return a.push.apply(a,s||[]),r()}function r(){for(var e,t=0;t<a.length;t++){for(var r=a[t],n=!0,i=1;i<r.length;i++){var c=r[i];0!==o[c]&&(n=!1)}n&&(a.splice(t--,1),e=l(l.s=r[0]))}return e}var n={},o={app:0},a=[];function i(e){return l.p+"js/"+({Book:"Book"}[e]||e)+"."+{Book:"a16a336a"}[e]+".js"}function l(t){if(n[t])return n[t].exports;var r=n[t]={i:t,l:!1,exports:{}};return e[t].call(r.exports,r,r.exports,l),r.l=!0,r.exports}l.e=function(e){var t=[],r=o[e];if(0!==r)if(r)t.push(r[2]);else{var n=new Promise((function(t,n){r=o[e]=[t,n]}));t.push(r[2]=n);var a,c=document.createElement("script");c.charset="utf-8",c.timeout=120,l.nc&&c.setAttribute("nonce",l.nc),c.src=i(e);var s=new Error;a=function(t){c.onerror=c.onload=null,clearTimeout(u);var r=o[e];if(0!==r){if(r){var n=t&&("load"===t.type?"missing":t.type),a=t&&t.target&&t.target.src;s.message="Loading chunk "+e+" failed.\n("+n+": "+a+")",s.name="ChunkLoadError",s.type=n,s.request=a,r[1](s)}o[e]=void 0}};var u=setTimeout((function(){a({type:"timeout",target:c})}),12e4);c.onerror=c.onload=a,document.head.appendChild(c)}return Promise.all(t)},l.m=e,l.c=n,l.d=function(e,t,r){l.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:r})},l.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},l.t=function(e,t){if(1&t&&(e=l(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var r=Object.create(null);if(l.r(r),Object.defineProperty(r,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var n in e)l.d(r,n,function(t){return e[t]}.bind(null,n));return r},l.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return l.d(t,"a",t),t},l.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},l.p="/",l.oe=function(e){throw console.error(e),e};var c=window["webpackJsonp"]=window["webpackJsonp"]||[],s=c.push.bind(c);c.push=t,c=c.slice();for(var u=0;u<c.length;u++)t(c[u]);var p=s;a.push([0,"chunk-vendors"]),r()})({0:function(e,t,r){e.exports=r("56d7")},"56d7":function(e,t,r){"use strict";r.r(t);r("e260"),r("e6cf"),r("cca6"),r("a79d");var n=r("2b0e"),o=function(){var e=this,t=e.$createElement,r=e._self._c||t;return r("div",{attrs:{id:"app"}},[r("b-container",[r("router-view")],1)],1)},a=[],i=r("57da"),l={name:"app",components:{Home:i["default"]}},c=l,s=r("2877"),u=Object(s["a"])(c,o,a,!1,null,null,null),p=u.exports,d=r("5f5b"),f=r("b1e0"),h=(r("f9e3"),r("2dd8"),r("d3b7"),r("8c4f"));n["default"].use(h["a"]);var b=function(){return Promise.resolve().then(r.bind(null,"57da"))},m=function(){return r.e("Book").then(r.bind(null,"c71c"))},v=new h["a"]({routes:[{path:"/",component:b},{name:"book_view",path:"/book/:id",component:m,props:!0}]}),g=v;n["default"].use(d["a"]),n["default"].use(f["a"]),n["default"].config.productionTip=!1,new n["default"]({router:g,render:function(e){return e(p)}}).$mount("#app")},"57da":function(e,t,r){"use strict";r.r(t);var n=function(){var e=this,t=e.$createElement,r=e._self._c||t;return r("div",{staticClass:"home"},[r("h1",[e._v("Vue")]),[r("div",[r("b-form-input",{attrs:{placeholder:"Search Titles"},model:{value:e.title,callback:function(t){e.title=t},expression:"title"}})],1),r("div",[r("b-form-input",{attrs:{placeholder:"Search Description"},model:{value:e.description,callback:function(t){e.description=t},expression:"description"}})],1),r("div",[r("b-form-input",{attrs:{placeholder:"Enter Page Size"},model:{value:e.pageSize,callback:function(t){e.pageSize=t},expression:"pageSize"}})],1)],r("div",[r("b-button",{attrs:{variant:"success"},on:{click:e.SearchBooks}},[e._v("Search")]),e._v(" "),r("b-button",{attrs:{variant:"warning"},on:{click:e.ClearSearchFilter}},[e._v("Clear")])],1),r("b-pagination",{attrs:{"total-rows":e.totalItems,"per-page":e.pageSize,"aria-controls":"books-table"},model:{value:e.currentPage,callback:function(t){e.currentPage=t},expression:"currentPage"}}),r("p",{staticClass:"mt-3"},[e._v("Current Page: "+e._s(e.currentPage))]),r("b-table",{attrs:{id:"books-table",striped:"",hover:"",items:e.items,fields:e.fields,responsive:"sm","current-page":e.currentPage,"per-page":0},scopedSlots:e._u([{key:"cell(thumbnailUrl)",fn:function(e){return[r("b-img",{attrs:{src:e.value,thumbnail:"",fluid:""}})]}},{key:"cell(title_link)",fn:function(t){return[r("b-link",{attrs:{to:{name:"book_view",params:{id:t.item.bookId}}}},[e._v(e._s(t.item.title))])]}}])})],2)},o=[],a=(r("a4d3"),r("e01a"),r("bc3a")),i=r.n(a),l={name:"Home",data:function(){return{fields:[{key:"thumbnailUrl",label:"Book Image"},{key:"title_link",label:"Book Title",sortable:!0,sortDirection:"desc"},{key:"isbn",label:"ISBN",sortable:!0,sortDirection:"desc"},{key:"publishedDate",label:"Published Date",sortable:!0,sortDirection:"desc"},{key:"shortDescr",label:"Description",sortable:!0,sortDirection:"desc"}],items:[],pageSize:10,totalItems:0,currentPage:1,title:"",description:""}},mounted:function(){var e=this;this.SearchBooks().catch((function(t){e.console.error(t)}))},methods:{SearchBooks:function(){var e=this;i.a.post("https://localhost:5001/books/BookSearch",{title:this.title,description:this.description,pageNumber:this.currentPage,pageSize:this.pageSize}).then((function(t){return e.totalItems=t.data["rowCount"],e.currentPage=t.data["currentPage"],e.items=t.data.results,t.data.results})).then((function(e){return e}))},ClearSearchFilter:function(){this.title="",this.description=""}},watch:{currentPage:{handler:function(){var e=this;this.SearchBooks().catch((function(t){e.console.error(t)}))}}}},c=l,s=r("2877"),u=Object(s["a"])(c,n,o,!1,null,"b8d0e946",null);t["default"]=u.exports}});
//# sourceMappingURL=app.9439047d.js.map