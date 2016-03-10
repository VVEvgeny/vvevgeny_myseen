(function(){var c=window.AmCharts;c.AmGanttChart=c.Class({inherits:c.AmSerialChart,construct:function(a){this.type="gantt";c.AmGanttChart.base.construct.call(this,a);this.cname="AmGanttChart";this.period="ss"},initChart:function(){this.processGanttData();this.dataChanged=!0;c.AmGanttChart.base.initChart.call(this)},parseData:function(){c.AmSerialChart.base.parseData.call(this);this.parseSerialData(this.ganttDataProvider)},processGanttData:function(){var a;this.graphs=[];var v=this.dataProvider;this.ganttDataProvider=
[];var w=this.categoryField,z=this.startField,A=this.endField,B=this.durationField,C=this.startDateField,D=this.endDateField,r=this.colorField,f=this.period,n=c.getDate(this.startDate,this.dataDateFormat,"fff");this.categoryAxis.gridPosition="start";a=this.valueAxis;this.valueAxes=[a];var x;"date"==a.type&&(x=!0);a.minimumDate&&(a.minimumDate=c.getDate(a.minimumDate,q,f));a.maximumDate&&(a.maximumDate=c.getDate(a.maximumDate,q,f));isNaN(a.minimum)||(a.minimumDate=c.changeDate(new Date(n),f,a.minimum,
!0,!0));isNaN(a.maximum)||(a.maximumDate=c.changeDate(new Date(n),f,a.maximum,!0,!0));var q=this.dataDateFormat;for(a=0;a<v.length;a++){var e=v[a],h={};h[w]=e[w];var t=e[this.segmentsField],p;this.ganttDataProvider.push(h);e=e[r];if(t)for(var k=0;k<t.length;k++){var d=t[k],b=d[z],g=d[A],l=d[B];isNaN(b)&&(b=p);isNaN(l)||(g=b+l);var l="start_"+a+"_"+k,u="end_"+a+"_"+k;h[l]=b;h[u]=g;p="lineColor color alpha fillColors description bullet customBullet bulletSize bulletConfig url labelColor dashLength pattern gap className".split(" ");
for(var E in p){var m=this.graph[p[E]+"Field"];m&&(h[m]=d[m])}p=g;if(x){var m=c.getDate(d[C],q,f),y=c.getDate(d[D],q,f);n&&(isNaN(b)||(m=c.changeDate(new Date(n),f,b,!0,!0)),isNaN(g)||(y=c.changeDate(new Date(n),f,g,!0,!0)));h[l]=m.getTime();h[u]=y.getTime()}g={};c.copyProperties(d,g);b={};c.copyProperties(this.graph,b,!0);b.customData=g;b.segmentData=d;b.labelFunction=this.graph.labelFunction;b.balloonFunction=this.graph.balloonFunction;b.customBullet=this.graph.customBullet;b.type="column";b.openField=
l;b.valueField=u;b.clustered=!1;d[r]&&(e=d[r]);b.columnWidth=d[this.columnWidthField];void 0===e&&(e=this.colors[a]);(d=this.brightnessStep)&&(e=c.adjustLuminosity(e,k*d/100));void 0===this.graph.lineColor&&(b.lineColor=e);void 0===this.graph.fillColors&&(b.fillColors=e);this.graphs.push(b)}}}})})();