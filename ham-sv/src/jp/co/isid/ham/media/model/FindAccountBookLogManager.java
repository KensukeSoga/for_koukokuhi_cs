package jp.co.isid.ham.media.model;

import java.util.List;
import jp.co.isid.ham.model.base.HAMException;

public class FindAccountBookLogManager {

    /** �V���O���g���C���X�^���X */
    private static FindAccountBookLogManager _manager = new FindAccountBookLogManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindAccountBookLogManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindAccountBookLogManager getInstance() {
        return _manager;
    }

    /**
     * �c�ƍ�Ƒ䒠�����������܂�
     *
     * @return FindCampaignListResult �c�ƍ�Ƒ䒠���
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public FindAccountBookLogResult findAccountBookLog(FindAccountBookLogCondition cond)
            throws HAMException {

        //��������
        FindAccountBookLogResult result = new FindAccountBookLogResult();

        // ******************************************************
        // �c�ƍ�Ƒ䒠�ύX���O���̎擾
        // ******************************************************
        FindAccountBookLogDAO dao = FindAccountBookLogDAOFactory.createFindAccountBookLogDAO();
        List<FindAccountBookLogVO> list = dao.FindEigyoDaichoHistory(cond.getDaichono());
        result.setLogAccountBook(list);

        return result;
    }

}
