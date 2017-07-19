package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj11CrCreateDataVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR�����Ǘ�(�����ݒ�p)����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/1/31 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCrCreateDataForCmsResult extends AbstractServiceResult {

    /** CR�����Ǘ� */
    private List<Tbj11CrCreateDataVO> _crCreateDataList;

    /**
     * CR�����Ǘ����擾����
     *
     * @return CR�����Ǘ�
     */
    public List<Tbj11CrCreateDataVO> getCrCreateData() {
        return _crCreateDataList;
    }

    /**
     * CR�����Ǘ���ݒ肷��
     *
     * @param crCreateDataList CR�����Ǘ�
     */
    public void setCrCreateData(List<Tbj11CrCreateDataVO> crCreateDataList) {
        _crCreateDataList = crCreateDataList;
    }
}
