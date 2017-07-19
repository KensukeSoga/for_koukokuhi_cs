package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

public class FindAccountBookOutPutDataCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �}�̃R�[�h */
    private String _mediacd = null;

    /** �Ԏ�R�[�h */
//    private String _dcarcd = null;

    /** �t�F�C�Y */
    private BigDecimal _phase = null;

    /** ���ԊJ�n */
    private String _kikanfrom = null;

    /** ���ԏI�� */
    private String _kikanto = null;

    /** �����Ώۃt���O */
    private boolean _seikyuflg;

    /** ���܂����t���O */
    private boolean _kimatagiflg;

    /** �Ԏ탊�X�g */
    private List<String> _carList = null;

    /** �S����ID */
    private String _hamid = null;

    /**
     * �}�̃R�[�h���擾����
     * @return �}�̃R�[�h
     */
    public String getMediacd() {
        return _mediacd;
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     * @param kikanfrom
     */
    public void setMediacd(String mediacd) {
        this._mediacd = mediacd;
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }

    /**
     * ���ԊJ�n���擾����
     * @return ���ԊJ�n
     */
    public String getKikanfrom() {
        return _kikanfrom;
    }

    /**
     * ���ԊJ�n��ݒ肷��
     * @param kikanfrom
     */
    public void setKikanfrom(String kikanfrom) {
        this._kikanfrom = kikanfrom;
    }

    /**
     * ���ԏI�����擾����
     * @return ���ԏI��
     */
    public String getKikanto() {
        return _kikanto;
    }

    /**
     * ���ԏI����ݒ肷��
     * @param kikanfrom
     */
    public void setKikanto(String kikanto) {
        this._kikanto = kikanto;
    }

    /**
     * �����Ώۃt���O���擾����
     * @return �����Ώۃt���O
     */
    public boolean getSeikyuflg() {
        return _seikyuflg;
    }

    /**
     * �����Ώۃt���O��ݒ肷��
     * @param seikyuflg
     */
    public void setSeikyuflg(boolean seikyuflg) {
        this._seikyuflg = seikyuflg;
    }

    /**
     * ���܂����t���O���擾����
     * @return ���܂����t���O
     */
    public boolean getKimatagiflg() {
        return _kimatagiflg;
    }

    /**
     * ���܂����t���O��ݒ肷��
     * @param seikyuflg
     */
    public void setKimatagiflg(boolean kimatagiflg) {
        this._kimatagiflg = kimatagiflg;
    }

    /**
     * �Ԏ탊�X�g���擾����
     *
     * @return carList
     */
    public List<String> getCarList() {
        return _carList;
    }

    /**
     * �Ԏ탊�X�g��ݒ肷��
     * @param carList �Ԏ탊�X�g
     */
    public void setCarList(List<String> carList) {
        this._carList = carList;
    }

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
}
