package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.base.HAMException;

public class UpdABOrderOutRegisterManager {

    /** �V���O���g���C���X�^���X */
    private static UpdABOrderOutRegisterManager _manager = new UpdABOrderOutRegisterManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private UpdABOrderOutRegisterManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static UpdABOrderOutRegisterManager getInstance() {
        return _manager;
    }

    /**
     * �c�ƍ�Ƒ䒠���X�V���܂�
     * @throws HAMException
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public void UpdAccountBookOutFlg(UpdABOrderOutRegisterVO vo) throws HAMException {

        UpdABOrderOutRegisterDAO dao = UpdABOrderOutRegisterDAOFactory.createUpdABOrderOutRegisterDAO();

        //�X�V
        if (vo.getUpdVo() != null && !vo.getUpdVo().equals("")) {

            for (Tbj02EigyoDaichoVO updvo : vo.getUpdVo()) {
                dao.updAccounBook(updvo);
            }
        }
    }

}
