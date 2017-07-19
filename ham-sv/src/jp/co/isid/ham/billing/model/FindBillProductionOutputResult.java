/**
 *
 */
package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * ���쐿���\�擾Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/18 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindBillProductionOutputResult extends AbstractServiceResult {

    /** ���쐿���\VO���X�g */
    List<FindBillProductionOutputVO> _findBillProductOutList;

    /**
     * ���쐿���\VO���X�g���擾����
     *
     * @return ���쐿���\VO���X�g
     */
    public List<FindBillProductionOutputVO> getFindBillProductionOutput() {
        return _findBillProductOutList;
    }

    /**
     * ���쐿���\VO���X�g��ݒ肷��
     *
     * @param fc ���쐿���\VO���X�g
     */
    public void setFindBillProductionOutput(List<FindBillProductionOutputVO> voList) {
    	_findBillProductOutList = voList;
    }
}