package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListCondition;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAO;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAOFactory;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindSozaiDataByRCodeManager {

    /** �V���O���g���C���X�^���X */
    private static FindSozaiDataByRCodeManager _manager = new FindSozaiDataByRCodeManager();

    /** �C���X�^���X���̋֎~ */
    private FindSozaiDataByRCodeManager() {
    }

    /**
     * �C���X�^���X��Ԃ�
     * @return �C���X�^���X
     */
    public static FindSozaiDataByRCodeManager getInstance() {
        return _manager;
    }

    /**
     * �f�ފǗ����X�g����������
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindSozaiDataByRCodeResult findSozaiDataByRCode(Tbj20SozaiKanriListCondition cond)
            throws HAMException {

        FindSozaiDataByRCodeResult result = new FindSozaiDataByRCodeResult();

        //�f�ފǗ����X�g����������
        Tbj20SozaiKanriListDAO sozaidao = Tbj20SozaiKanriListDAOFactory.createTbj20SozaiKanriListDAO();
        List<Tbj20SozaiKanriListVO> sozaivolist = sozaidao.FindSozaiKanriByRCode(cond);
        result.setSozaiKanriList(sozaivolist);

        return result;
    }
}
