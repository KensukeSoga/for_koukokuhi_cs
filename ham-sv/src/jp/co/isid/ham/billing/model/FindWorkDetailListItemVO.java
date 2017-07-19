package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;

/**
 * <P>
 * �����׏��o�͈ꗗ�擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/5 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindWorkDetailListItemVO extends FindEstimateDetailVO {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindWorkDetailListItemVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindWorkDetailListItemVO();
    }

    /**
     * �����Ǘ�NO���擾����
     *
     * @return �����Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQUENCENO() {
        return (BigDecimal) get(Tbj07EstimateCreate.SEQUENCENO);
    }

    /**
     * �����Ǘ�NO��ݒ肷��
     *
     * @param val �����Ǘ�NO
     */
    public void setSEQUENCENO(BigDecimal val) {
        set(Tbj07EstimateCreate.SEQUENCENO, val);
    }
}
