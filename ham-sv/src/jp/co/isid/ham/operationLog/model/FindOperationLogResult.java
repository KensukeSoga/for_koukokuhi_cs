package jp.co.isid.ham.operationLog.model;

import java.util.List;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �ғ����O����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/05/15 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindOperationLogResult extends AbstractServiceResult {

    /** �ғ����OVO���X�g */
    List<FindOperationLogVO> _findOperationLogList;

    /**
     * �ғ����OVO���X�g���擾����
     *
     * @return �ғ����OVO���X�g
     */
    public List<FindOperationLogVO> getFindOperationLog() {
        return _findOperationLogList;
    }

    /**
     * �ғ����OVO���X�g��ݒ肷��
     *
     * @param fc �ғ����OVO���X�g
     */
    public void setFindOperationLog(List<FindOperationLogVO> voList) {
    	_findOperationLogList = voList;
    }
}
