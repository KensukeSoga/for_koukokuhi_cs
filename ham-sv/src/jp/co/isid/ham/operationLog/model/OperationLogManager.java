package jp.co.isid.ham.operationLog.model;

import jp.co.isid.ham.common.model.Tbj28WorkLogDAO;
import jp.co.isid.ham.common.model.Tbj28WorkLogDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
*
* <P>
* �ғ����O�f�[�^���Ǘ�����
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2013/05/15 T.Kobayashi)<BR>
* </P>
*
* @author T.Kobayashi
*/
public class OperationLogManager {

    /** �V���O���g���C���X�^���X */
    private static OperationLogManager _manager = new OperationLogManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private OperationLogManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static OperationLogManager getInstance() {
        return _manager;
    }

    /**
     * �ғ����O�̕\���f�[�^���擾���܂�
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindOperationLogResult findOperationLog(FindOperationLogCondition cond) throws HAMException {

    	FindOperationLogResult result = new FindOperationLogResult();

        // �ғ����O�擾DAO
    	FindOperationLogDAO dao = FindOperationLogDAOFactory.createFindOperationLogDAO();
    	result.setFindOperationLog(dao.selectVO(cond));

        return result;
    }

    /**
     * �ғ����O��o�^���܂�
     * @param vo �o�^���
     * @return ��������
     * @throws HAMException
     */
    public RegisterOperationLogResult registerOperationLog(RegisterOperationLogVO vo) throws HAMException {

        RegisterOperationLogResult result = new RegisterOperationLogResult();

        // �ғ����O�o�^
        Tbj28WorkLogDAO dao = Tbj28WorkLogDAOFactory.createTbj28WorkLogDAO();
        dao.insertVO(vo.getWorkLogVo());

        return result;
    }
}
