new Vue({
    el: "#exercise",
    data: {
        jobInfo: [],
        addInfo: {},
        indexUpdate: "",
        showForm: false,
        editForm: false
    },
    methods: {
        getInfo: function () {
            //get request
            this.$http.get('/startex').then(response => {
                this.jobInfo = response.body;
            });
        },
        addJobs: function () {
            this.$http.post("/startex/add", this.addInfo).then((r) => {
                this.addInfo.Id = r.body.id;
                this.jobInfo.push(this.addInfo);
                this.addInfo = {};
                this.showForm = false;

            });
        },
        deleteJobs: function (Id, index) {
            if (confirm("Are you sure you want to delete this job?")) {
                this.$http.delete("/startex/remove/" + Id).then(() => { this.jobInfo.splice(index, 1) });
            }
        },
        updateJobs: function () {
            this.$http.put("/startex/update/" + this.addInfo.Id, this.addInfo).then(() => {
                this.editForm = false;
                this.showForm = false;
                this.jobInfo.splice(this.indexUpdate, 1, this.addInfo);
                this.addInfo = {};
                this.indexUpdate = "";
            });
        },
        editInfo: function (info, i) {
            this.addInfo = Object.assign({}, info);
            this.indexUpdate = i;
            this.showForm = true;
            this.editForm = true;
        },
        cancelForm: function () {
            this.showForm = false;
            this.editForm = false;
            this.addInfo = {};
        }
    },
    created() {
        this.getInfo();
    }
});