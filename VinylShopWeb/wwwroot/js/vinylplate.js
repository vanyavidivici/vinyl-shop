var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#vinylData').DataTable({
        "language": {
            "lengthMenu": "Показати _MENU_ записів",
            "infoFiltered": "(відфільтровано з _MAX_ записів)",
            "search": "Пошук:",
            "paginate": {
                "first": "Перша",
                "previous": "Попередня",
                "next": "Наступна",
                "last": "Остання"
            },
            "aria": {
                "sortAscending": ": активуйте, щоб сортувати колонку за зростанням",
                "sortDescending": ": активуйте, щоб сортувати колонку за спаданням"
            },
            "autoFill": {
                "cancel": "Відміна",
                "fill": "Заповнити всі клітинки з <i>%d<\/i>",
                "fillHorizontal": "Заповнити клітинки горизонтально",
                "fillVertical": "Заповнити клітинки вертикально"
            },
            "buttons": {
                "collection": "Список <span class=\"ui-button-icon-primary ui-icon ui-icon-triangle-1-s\"><\/span>",
                "colvis": "Видимість колонки",
                "colvisRestore": "Відновити видимість",
                "copy": "Копіювати",
                "copyKeys": "Нажміть ctrl або u2318 + C щоб копіювати інформацію з таблиці до вашого буферу обміну.<br \/><br \/>Щоб відмінити нажміть на це повідомлення або Esc",
                "copySuccess": {
                    "1": "Скопійовано 1 рядок в буфер обміну",
                    "_": "Скопійовано %d рядків в буфер обміну"
                },
                "copyTitle": "Копіювати в буфер обміну",
                "csv": "CSV",
                "excel": "Excel",
                "pageLength": {
                    "-1": "Показати усі рядки",
                    "_": "Показати %d рядки"
                },
                "pdf": "PDF",
                "print": "Друкувати"
            },
            "emptyTable": "Ця таблиця не містить даних",
            "info": "Показано від _START_ по _END_ з _TOTAL_ записів",
            "infoEmpty": "Показано від 0 по 0 з 0 записів",
            "infoThousands": ",",
            "loadingRecords": "Завантаження",
            "processing": "Опрацювання...",
            "searchBuilder": {
                "add": "Додати умову",
                "button": {
                    "0": "Розширений пошук",
                    "_": "Розширений пошук (%d)"
                },
                "clearAll": "Очистити все",
                "condition": "Умова",
                "conditions": {
                    "date": {
                        "after": "Після",
                        "before": "До",
                        "between": "Між",
                        "empty": "Пусто",
                        "equals": "Дорівнює",
                        "not": "Не",
                        "notBetween": "Не між",
                        "notEmpty": "Не пусто"
                    },
                    "number": {
                        "between": "Між",
                        "empty": "Пусто",
                        "equals": "Дорівнює",
                        "gt": "Більше ніж",
                        "gte": "Більше або дорівнює",
                        "lt": "Менше ніж",
                        "lte": "Менше або дорівнює",
                        "not": "Не",
                        "notBetween": "Не між",
                        "notEmpty": "Не пусто"
                    },
                    "string": {
                        "contains": "Містить",
                        "empty": "Пусто",
                        "endsWith": "Закінчується з",
                        "equals": "Дорівнює",
                        "not": "Не",
                        "notEmpty": "Не пусто",
                        "startsWith": "Починається з"
                    }
                },
                "data": "Дата",
                "deleteTitle": "Видалити правило фільтрування",
                "leftTitle": "Відступні критерії",
                "logicAnd": "I",
                "logicOr": "Або",
                "rightTitle": "Відступні критерії",
                "title": {
                    "0": "Розширений пошук",
                    "_": "Розширений пошук (%d)"
                },
                "value": "Значення"
            },
            "searchPanes": {
                "clearMessage": "Очистити все",
                "collapse": {
                    "0": "Пошукові Панелі",
                    "_": "Пошукові Панелі (%d)"
                },
                "count": "{total}",
                "countFiltered": "{shown} ({total})",
                "emptyPanes": "Немає Пошукових Панелей",
                "loadMessage": "Завантаження Пошукових Панелей",
                "title": "Активній фільтри - %d"
            },
            "select": {
                "cells": {
                    "1": "1 клітинку вибрано",
                    "_": "%d клітинок вибрано"
                },
                "columns": {
                    "1": "1 колонку вибрано",
                    "_": "%d колонок вибрано"
                }
            },
            "thousands": ",",
            "zeroRecords": "Не знайдено жодних записів",
            "editor": {
                "close": "Закрити",
                "create": {
                    "button": "Cтворити нову",
                    "title": "Cтворити новий запис",
                    "submit": "Cтворити"
                },
                "edit": {
                    "button": "Редагувати",
                    "title": "Редагувати запис",
                    "submit": "Оновити"
                },
                "remove": {
                    "button": "Видалити",
                    "title": "Видалити",
                    "submit": "Видалити"
                }
            },
            "datetime": {
                "minutes": "Хвилина",
                "months": {
                    "0": "Січень",
                    "1": "Лютий",
                    "10": "Листопад",
                    "11": "Грудень",
                    "2": "Березень",
                    "3": "Квітень",
                    "4": "Травень",
                    "5": "Червень",
                    "6": "Липень",
                    "7": "Серпень",
                    "8": "Вересень",
                    "9": "Жовтень"
                },
                "next": "Наступні",
                "previous": "Попередні",
                "seconds": "Секунда",
                "unknown": "-",
                "weekdays": [
                    "Неділя",
                    "Понеділок",
                    "Вівторок",
                    "Середа",
                    "Четверг",
                    "П'ятниця",
                    "Субота"
                ]
            }
        },
        "ajax": {
            "url": "/Admin/VinylPlate/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "author.name", "width": "15%" },
            { "data": "label.name", "width": "15%" },
            { "data": "format", "width": "15%" },
            { "data": "format", "width": "15%" },
            { "data": "code", "width": "15%" },
            { "data": "price", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/VinylPlate/Upsert?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Редагувати</a>
                       <a onClick=Delete('/Admin/VinylPlate/Delete/${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Видалити</a>
					</div>
                        `
                },
                "width": "15%"
            },

        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Ви бажаєте видалити запис?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Так',
        cancelButtonText: 'Ні'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}