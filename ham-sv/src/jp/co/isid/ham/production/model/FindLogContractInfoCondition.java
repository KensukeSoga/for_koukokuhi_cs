package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �_����o�^�@�������s���̃f�[�^�擾�����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/15 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindLogContractInfoCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �S����ID */
    private String _hamid = null;

    /** �����L�[ */
    private BigDecimal _historykey = null;

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param hamid �S����ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * �����L�[���擾����
     *
     * @return �����L�[
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHistorykey() {
        return _historykey;
    }

    /**
     * �����L�[��ݒ肷��
     *
     * @param historykey �����L�[
     */
    public void setHistorykey(BigDecimal historykey) {
        this._historykey = historykey;
    }
}
