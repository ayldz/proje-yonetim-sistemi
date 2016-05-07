$("document").ready(init);

function init() {
    expand();
    renderDateTables();
    renderDatePickers();
    renderSelects();
}

function expand() {
    var height = window.innerHeight;
    $("#page-wrapper").css("height", height - 50);
    $("#page-wrapper").css("overflow", "scroll-x");
}

function renderDateTables() {
    $(".datatable").DataTable({
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun soralamasını aktifleştir"
            }
        }
    });
}

function renderDatePickers() {
    $('[data-type="date"]').datepicker({
        format: "dd/mm/yyyy",
        language: "tr",
        todayHighlight: true
    });
}

function renderSelects() {
    $('.select2').select2();
}