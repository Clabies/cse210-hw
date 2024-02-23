using System;
using System.Collections.Generic;

record ResponseDTO(
    int Score,
    List<RequestDTO> RequestDTOList
);