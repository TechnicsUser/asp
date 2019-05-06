$(function () {
    $(":file").change(function () {
        if (this.files && this.files[0]) {
            for (var i = 0; i < this.files.length; i++) {
                var reader = new FileReader();
                reader.onload = imageIsLoaded;
                reader.readAsDataURL(this.files[i]);
            }
        }
    });
});

function imageIsLoaded(e) {
    $('#myImg').append('<img src=' + e.target.result + '>');
}
