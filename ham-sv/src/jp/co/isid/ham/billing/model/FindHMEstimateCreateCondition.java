package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM���ψČ�CR����������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateCreateCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���ϖ��׊Ǘ�NO���X�g */
    List<BigDecimal> _estSeqNoList;

    /**
     * ���ϖ��׊Ǘ�NO���擾����
     * @return List<BigDecimal> ���ϖ��׊Ǘ�NO���X�g
     */
    public List<BigDecimal> getEstSeqNoList() {
        return _estSeqNoList;
    }

    /**
     * ���ϖ��׊Ǘ�NO���X�g��ݒ肷��
     * @param estDetailSeqNo List<BigDecimal> ���ϖ��׊Ǘ�NO���X�g
     */
    public void setEstSeqNoList(List<BigDecimal> val) {
        _estSeqNoList = val;
    }

}
