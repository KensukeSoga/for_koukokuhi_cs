package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �c�ƍ�Ƒ䒠�ύX���O��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj23LogEigyoDaichoCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �}�̊Ǘ�No */
    private BigDecimal _mediaplanno = null;

    /** �䒠No */
    private String _daichono = null;

    /** ����NO */
    private BigDecimal _historyno = null;

    /** �����敪 */
    private String _historykbn = null;

    /** IMP�L�[ */
    private String _impkey = null;

    /** �����N�� */
    private Date _seikyuym = null;

    /** �}�̃R�[�h */
    private String _mediacd = null;

    /** �}�̎�ʃR�[�h */
    private String _mediascd = null;

    /** �}�̎�ʖ� */
    private String _mediasnm = null;

    /** �n��R�[�h */
    private String _keiretsucd = null;

    /** �d�ʎԎ�R�[�h */
    private String _dcarcd = null;

    /** ��p�v��No */
    private String _hiyouno = null;

    /** ���No */
    private String _kikakuno = null;

    /** �L�����y�[���� */
    private String _campaign = null;

    /** ���e��� */
    private String _naiyohimoku = null;

    /** �X�y�[�X�i�V���̂݁j */
    private String _space = null;

    /** ���[�i�V���̂݁j */
    private String _npdivision = null;

    /** �f�ڔŁi�V���̂݁j */
    private String _publishver = null;

    /** �L�G�敪�i�V���̂݁j */
    private String _symboldivision = null;

    /** �f�ږʁi�V���̂݁j */
    private String _postedsurface = null;

    /** �P�ʁi�V���̂݁j */
    private String _unit = null;

    /** �_��敪�i�V���̂݁j */
    private String _contractdivision = null;

    /** ���ԊJ�n */
    private Date _kikanfrom = null;

    /** ���ԏI�� */
    private Date _kikanto = null;

    /** �������̓t���O */
    private String _genkaflg = null;

    /** �O���X���z */
    private BigDecimal _gross = null;

    /** �d�ʒl���� */
    private BigDecimal _dnebikiritsu = null;

    /** �d�ʒl���z */
    private BigDecimal _dnebikigaku = null;

    /** H�V���f���R�X�g */
    private BigDecimal _hmcost = null;

    /** �c�Ɛ\�����v�� */
    private BigDecimal _aplriekiritsu = null;

    /** �c�Ɛ\�����v�z */
    private BigDecimal _aplriekigaku = null;

    /** �}�̎Е����z */
    private BigDecimal _mediaharai = null;

    /** �}�̃}�[�W���� */
    private BigDecimal _mediamarginritsu = null;

    /** �}�̃}�[�W���z */
    private BigDecimal _mediamargingaku = null;

    /** �}�̌��� */
    private BigDecimal _mediagenka = null;

    /** �戵���v�z */
    private BigDecimal _toririeki = null;

    /** �ʏ험�v�z���z */
    private BigDecimal _riekihaibun = null;

    /** �ʏ���Η��v�z */
    private BigDecimal _naikinrieki = null;

    /** �U�֗��v�z���z */
    private BigDecimal _furikaerieki = null;

    /** �c�Ɨv���z */
    private BigDecimal _eigyoyoin = null;

    /** �U�֗��v�z���z2 */
    private BigDecimal _furikaerieki2 = null;

    /** �e���r�^�C���}�̎Е��P�� */
    private BigDecimal _tvtmediatanka = null;

    /** �e���r�^�C��HM�P�� */
    private BigDecimal _tvthmtanka = null;

    /** �F�����i�V���̂݁j */
    private BigDecimal _colorfee = null;

    /** �w�藿�i�V���̂݁j */
    private BigDecimal _designationfee = null;

    /** ��A�ŗ��i�V���̂݁j */
    private BigDecimal _doublefee = null;

    /** �g�֗��i�V���̂݁j */
    private BigDecimal _reclassificationfee = null;

    /** �ό`�X�y�[�X���i�V���̂݁j */
    private BigDecimal _spacefee = null;

    /** �X�v���b�g�������i�V���̂݁j */
    private BigDecimal _splitrunfee = null;

    /** �˗���i�V���̂݁j */
    private String _requestdestination = null;

    /** ������ */
    private String _brddate = null;

    /** ���l */
    private String _biko = null;

    /** �����Ώۃt���O */
    private String _seikyuflg = null;

    /** ���t�ݒ�(���W�I�^�C���̂�) */
    private String _cpdate = null;

    /** �b��(���W�I�^�C���̂�) */
    private BigDecimal _brdsec = null;

    /** �󒍃t�@�C���o�̓t���O�i�V���̂݁j */
    private String _fileoutflg = null;

    /** �f�ړ� */
    private Date _appearancedate = null;

    /** �\�[�g�� */
    private BigDecimal _sortno = null;

    /** �f�[�^�쐬���� */
    private Date _crtdate = null;

    /** �f�[�^�쐬�� */
    private String _crtnm = null;

    /** �쐬�v���O���� */
    private String _crtapl = null;

    /** �쐬�S����ID */
    private String _crtid = null;

    /** �f�[�^�X�V���� */
    private Date _upddate = null;

    /** �f�[�^�X�V�� */
    private String _updnm = null;

    /** �X�V�v���O���� */
    private String _updapl = null;

    /** �X�V�S����ID */
    private String _updid = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj23LogEigyoDaichoCondition() {
    }

    /**
     * �}�̊Ǘ�No���擾����
     *
     * @return �}�̊Ǘ�No
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMediaplanno() {
        return _mediaplanno;
    }

    /**
     * �}�̊Ǘ�No��ݒ肷��
     *
     * @param mediaplanno �}�̊Ǘ�No
     */
    public void setMediaplanno(BigDecimal mediaplanno) {
        this._mediaplanno = mediaplanno;
    }

    /**
     * �䒠No���擾����
     *
     * @return �䒠No
     */
    public String getDaichono() {
        return _daichono;
    }

    /**
     * �䒠No��ݒ肷��
     *
     * @param daichono �䒠No
     */
    public void setDaichono(String daichono) {
        this._daichono = daichono;
    }

    /**
     * ����NO���擾����
     *
     * @return ����NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHistoryno() {
        return _historyno;
    }

    /**
     * ����NO��ݒ肷��
     *
     * @param historyno ����NO
     */
    public void setHistoryno(BigDecimal historyno) {
        this._historyno = historyno;
    }

    /**
     * �����敪���擾����
     *
     * @return �����敪
     */
    public String getHistorykbn() {
        return _historykbn;
    }

    /**
     * �����敪��ݒ肷��
     *
     * @param historykbn �����敪
     */
    public void setHistorykbn(String historykbn) {
        this._historykbn = historykbn;
    }

    /**
     * IMP�L�[���擾����
     *
     * @return IMP�L�[
     */
    public String getImpkey() {
        return _impkey;
    }

    /**
     * IMP�L�[��ݒ肷��
     *
     * @param impkey IMP�L�[
     */
    public void setImpkey(String impkey) {
        this._impkey = impkey;
    }

    /**
     * �����N�����擾����
     *
     * @return �����N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getSeikyuym() {
        return _seikyuym;
    }

    /**
     * �����N����ݒ肷��
     *
     * @param seikyuym �����N��
     */
    public void setSeikyuym(Date seikyuym) {
        this._seikyuym = seikyuym;
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMediacd() {
        return _mediacd;
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param mediacd �}�̃R�[�h
     */
    public void setMediacd(String mediacd) {
        this._mediacd = mediacd;
    }

    /**
     * �}�̎�ʃR�[�h���擾����
     *
     * @return �}�̎�ʃR�[�h
     */
    public String getMediascd() {
        return _mediascd;
    }

    /**
     * �}�̎�ʃR�[�h��ݒ肷��
     *
     * @param mediascd �}�̎�ʃR�[�h
     */
    public void setMediascd(String mediascd) {
        this._mediascd = mediascd;
    }

    /**
     * �}�̎�ʖ����擾����
     *
     * @return �}�̎�ʖ�
     */
    public String getMediasnm() {
        return _mediasnm;
    }

    /**
     * �}�̎�ʖ���ݒ肷��
     *
     * @param mediasnm �}�̎�ʖ�
     */
    public void setMediasnm(String mediasnm) {
        this._mediasnm = mediasnm;
    }

    /**
     * �n��R�[�h���擾����
     *
     * @return �n��R�[�h
     */
    public String getKeiretsucd() {
        return _keiretsucd;
    }

    /**
     * �n��R�[�h��ݒ肷��
     *
     * @param keiretsucd �n��R�[�h
     */
    public void setKeiretsucd(String keiretsucd) {
        this._keiretsucd = keiretsucd;
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDcarcd() {
        return _dcarcd;
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param dcarcd �d�ʎԎ�R�[�h
     */
    public void setDcarcd(String dcarcd) {
        this._dcarcd = dcarcd;
    }

    /**
     * ��p�v��No���擾����
     *
     * @return ��p�v��No
     */
    public String getHiyouno() {
        return _hiyouno;
    }

    /**
     * ��p�v��No��ݒ肷��
     *
     * @param hiyouno ��p�v��No
     */
    public void setHiyouno(String hiyouno) {
        this._hiyouno = hiyouno;
    }

    /**
     * ���No���擾����
     *
     * @return ���No
     */
    public String getKikakuno() {
        return _kikakuno;
    }

    /**
     * ���No��ݒ肷��
     *
     * @param kikakuno ���No
     */
    public void setKikakuno(String kikakuno) {
        this._kikakuno = kikakuno;
    }

    /**
     * �L�����y�[�������擾����
     *
     * @return �L�����y�[����
     */
    public String getCampaign() {
        return _campaign;
    }

    /**
     * �L�����y�[������ݒ肷��
     *
     * @param campaign �L�����y�[����
     */
    public void setCampaign(String campaign) {
        this._campaign = campaign;
    }

    /**
     * ���e��ڂ��擾����
     *
     * @return ���e���
     */
    public String getNaiyohimoku() {
        return _naiyohimoku;
    }

    /**
     * ���e��ڂ�ݒ肷��
     *
     * @param naiyohimoku ���e���
     */
    public void setNaiyohimoku(String naiyohimoku) {
        this._naiyohimoku = naiyohimoku;
    }

    /**
     * �X�y�[�X�i�V���̂݁j���擾����
     *
     * @return �X�y�[�X�i�V���̂݁j
     */
    public String getSpace() {
        return _space;
    }

    /**
     * �X�y�[�X�i�V���̂݁j��ݒ肷��
     *
     * @param space �X�y�[�X�i�V���̂݁j
     */
    public void setSpace(String space) {
        this._space = space;
    }

    /**
     * ���[�i�V���̂݁j���擾����
     *
     * @return ���[�i�V���̂݁j
     */
    public String getNpdivision() {
        return _npdivision;
    }

    /**
     * ���[�i�V���̂݁j��ݒ肷��
     *
     * @param npdivision ���[�i�V���̂݁j
     */
    public void setNpdivision(String npdivision) {
        this._npdivision = npdivision;
    }

    /**
     * �f�ڔŁi�V���̂݁j���擾����
     *
     * @return �f�ڔŁi�V���̂݁j
     */
    public String getPublishver() {
        return _publishver;
    }

    /**
     * �f�ڔŁi�V���̂݁j��ݒ肷��
     *
     * @param publishver �f�ڔŁi�V���̂݁j
     */
    public void setPublishver(String publishver) {
        this._publishver = publishver;
    }

    /**
     * �L�G�敪�i�V���̂݁j���擾����
     *
     * @return �L�G�敪�i�V���̂݁j
     */
    public String getSymboldivision() {
        return _symboldivision;
    }

    /**
     * �L�G�敪�i�V���̂݁j��ݒ肷��
     *
     * @param symboldivision �L�G�敪�i�V���̂݁j
     */
    public void setSymboldivision(String symboldivision) {
        this._symboldivision = symboldivision;
    }

    /**
     * �f�ږʁi�V���̂݁j���擾����
     *
     * @return �f�ږʁi�V���̂݁j
     */
    public String getPostedsurface() {
        return _postedsurface;
    }

    /**
     * �f�ږʁi�V���̂݁j��ݒ肷��
     *
     * @param postedsurface �f�ږʁi�V���̂݁j
     */
    public void setPostedsurface(String postedsurface) {
        this._postedsurface = postedsurface;
    }

    /**
     * �P�ʁi�V���̂݁j���擾����
     *
     * @return �P�ʁi�V���̂݁j
     */
    public String getUnit() {
        return _unit;
    }

    /**
     * �P�ʁi�V���̂݁j��ݒ肷��
     *
     * @param unit �P�ʁi�V���̂݁j
     */
    public void setUnit(String unit) {
        this._unit = unit;
    }

    /**
     * �_��敪�i�V���̂݁j���擾����
     *
     * @return �_��敪�i�V���̂݁j
     */
    public String getContractdivision() {
        return _contractdivision;
    }

    /**
     * �_��敪�i�V���̂݁j��ݒ肷��
     *
     * @param contractdivision �_��敪�i�V���̂݁j
     */
    public void setContractdivision(String contractdivision) {
        this._contractdivision = contractdivision;
    }

    /**
     * ���ԊJ�n���擾����
     *
     * @return ���ԊJ�n
     */
    @XmlElement(required = true, nillable = true)
    public Date getKikanfrom() {
        return _kikanfrom;
    }

    /**
     * ���ԊJ�n��ݒ肷��
     *
     * @param kikanfrom ���ԊJ�n
     */
    public void setKikanfrom(Date kikanfrom) {
        this._kikanfrom = kikanfrom;
    }

    /**
     * ���ԏI�����擾����
     *
     * @return ���ԏI��
     */
    @XmlElement(required = true, nillable = true)
    public Date getKikanto() {
        return _kikanto;
    }

    /**
     * ���ԏI����ݒ肷��
     *
     * @param kikanto ���ԏI��
     */
    public void setKikanto(Date kikanto) {
        this._kikanto = kikanto;
    }

    /**
     * �������̓t���O���擾����
     *
     * @return �������̓t���O
     */
    public String getGenkaflg() {
        return _genkaflg;
    }

    /**
     * �������̓t���O��ݒ肷��
     *
     * @param genkaflg �������̓t���O
     */
    public void setGenkaflg(String genkaflg) {
        this._genkaflg = genkaflg;
    }

    /**
     * �O���X���z���擾����
     *
     * @return �O���X���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGross() {
        return _gross;
    }

    /**
     * �O���X���z��ݒ肷��
     *
     * @param gross �O���X���z
     */
    public void setGross(BigDecimal gross) {
        this._gross = gross;
    }

    /**
     * �d�ʒl�������擾����
     *
     * @return �d�ʒl����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDnebikiritsu() {
        return _dnebikiritsu;
    }

    /**
     * �d�ʒl������ݒ肷��
     *
     * @param dnebikiritsu �d�ʒl����
     */
    public void setDnebikiritsu(BigDecimal dnebikiritsu) {
        this._dnebikiritsu = dnebikiritsu;
    }

    /**
     * �d�ʒl���z���擾����
     *
     * @return �d�ʒl���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDnebikigaku() {
        return _dnebikigaku;
    }

    /**
     * �d�ʒl���z��ݒ肷��
     *
     * @param dnebikigaku �d�ʒl���z
     */
    public void setDnebikigaku(BigDecimal dnebikigaku) {
        this._dnebikigaku = dnebikigaku;
    }

    /**
     * H�V���f���R�X�g���擾����
     *
     * @return H�V���f���R�X�g
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHmcost() {
        return _hmcost;
    }

    /**
     * H�V���f���R�X�g��ݒ肷��
     *
     * @param hmcost H�V���f���R�X�g
     */
    public void setHmcost(BigDecimal hmcost) {
        this._hmcost = hmcost;
    }

    /**
     * �c�Ɛ\�����v�����擾����
     *
     * @return �c�Ɛ\�����v��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getAplriekiritsu() {
        return _aplriekiritsu;
    }

    /**
     * �c�Ɛ\�����v����ݒ肷��
     *
     * @param aplriekiritsu �c�Ɛ\�����v��
     */
    public void setAplriekiritsu(BigDecimal aplriekiritsu) {
        this._aplriekiritsu = aplriekiritsu;
    }

    /**
     * �c�Ɛ\�����v�z���擾����
     *
     * @return �c�Ɛ\�����v�z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getAplriekigaku() {
        return _aplriekigaku;
    }

    /**
     * �c�Ɛ\�����v�z��ݒ肷��
     *
     * @param aplriekigaku �c�Ɛ\�����v�z
     */
    public void setAplriekigaku(BigDecimal aplriekigaku) {
        this._aplriekigaku = aplriekigaku;
    }

    /**
     * �}�̎Е����z���擾����
     *
     * @return �}�̎Е����z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMediaharai() {
        return _mediaharai;
    }

    /**
     * �}�̎Е����z��ݒ肷��
     *
     * @param mediaharai �}�̎Е����z
     */
    public void setMediaharai(BigDecimal mediaharai) {
        this._mediaharai = mediaharai;
    }

    /**
     * �}�̃}�[�W�������擾����
     *
     * @return �}�̃}�[�W����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMediamarginritsu() {
        return _mediamarginritsu;
    }

    /**
     * �}�̃}�[�W������ݒ肷��
     *
     * @param mediamarginritsu �}�̃}�[�W����
     */
    public void setMediamarginritsu(BigDecimal mediamarginritsu) {
        this._mediamarginritsu = mediamarginritsu;
    }

    /**
     * �}�̃}�[�W���z���擾����
     *
     * @return �}�̃}�[�W���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMediamargingaku() {
        return _mediamargingaku;
    }

    /**
     * �}�̃}�[�W���z��ݒ肷��
     *
     * @param mediamargingaku �}�̃}�[�W���z
     */
    public void setMediamargingaku(BigDecimal mediamargingaku) {
        this._mediamargingaku = mediamargingaku;
    }

    /**
     * �}�̌������擾����
     *
     * @return �}�̌���
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMediagenka() {
        return _mediagenka;
    }

    /**
     * �}�̌�����ݒ肷��
     *
     * @param mediagenka �}�̌���
     */
    public void setMediagenka(BigDecimal mediagenka) {
        this._mediagenka = mediagenka;
    }

    /**
     * �戵���v�z���擾����
     *
     * @return �戵���v�z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getToririeki() {
        return _toririeki;
    }

    /**
     * �戵���v�z��ݒ肷��
     *
     * @param toririeki �戵���v�z
     */
    public void setToririeki(BigDecimal toririeki) {
        this._toririeki = toririeki;
    }

    /**
     * �ʏ험�v�z���z���擾����
     *
     * @return �ʏ험�v�z���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRiekihaibun() {
        return _riekihaibun;
    }

    /**
     * �ʏ험�v�z���z��ݒ肷��
     *
     * @param riekihaibun �ʏ험�v�z���z
     */
    public void setRiekihaibun(BigDecimal riekihaibun) {
        this._riekihaibun = riekihaibun;
    }

    /**
     * �ʏ���Η��v�z���擾����
     *
     * @return �ʏ���Η��v�z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNaikinrieki() {
        return _naikinrieki;
    }

    /**
     * �ʏ���Η��v�z��ݒ肷��
     *
     * @param naikinrieki �ʏ���Η��v�z
     */
    public void setNaikinrieki(BigDecimal naikinrieki) {
        this._naikinrieki = naikinrieki;
    }

    /**
     * �U�֗��v�z���z���擾����
     *
     * @return �U�֗��v�z���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getFurikaerieki() {
        return _furikaerieki;
    }

    /**
     * �U�֗��v�z���z��ݒ肷��
     *
     * @param furikaerieki �U�֗��v�z���z
     */
    public void setFurikaerieki(BigDecimal furikaerieki) {
        this._furikaerieki = furikaerieki;
    }

    /**
     * �c�Ɨv���z���擾����
     *
     * @return �c�Ɨv���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEigyoyoin() {
        return _eigyoyoin;
    }

    /**
     * �c�Ɨv���z��ݒ肷��
     *
     * @param eigyoyoin �c�Ɨv���z
     */
    public void setEigyoyoin(BigDecimal eigyoyoin) {
        this._eigyoyoin = eigyoyoin;
    }

    /**
     * �U�֗��v�z���z2���擾����
     *
     * @return �U�֗��v�z���z2
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getFurikaerieki2() {
        return _furikaerieki2;
    }

    /**
     * �U�֗��v�z���z2��ݒ肷��
     *
     * @param furikaerieki2 �U�֗��v�z���z2
     */
    public void setFurikaerieki2(BigDecimal furikaerieki2) {
        this._furikaerieki2 = furikaerieki2;
    }

    /**
     * �e���r�^�C���}�̎Е��P�����擾����
     *
     * @return �e���r�^�C���}�̎Е��P��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getTvtmediatanka() {
        return _tvtmediatanka;
    }

    /**
     * �e���r�^�C���}�̎Е��P����ݒ肷��
     *
     * @param tvtmediatanka �e���r�^�C���}�̎Е��P��
     */
    public void setTvtmediatanka(BigDecimal tvtmediatanka) {
        this._tvtmediatanka = tvtmediatanka;
    }

    /**
     * �e���r�^�C��HM�P�����擾����
     *
     * @return �e���r�^�C��HM�P��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getTvthmtanka() {
        return _tvthmtanka;
    }

    /**
     * �e���r�^�C��HM�P����ݒ肷��
     *
     * @param tvthmtanka �e���r�^�C��HM�P��
     */
    public void setTvthmtanka(BigDecimal tvthmtanka) {
        this._tvthmtanka = tvthmtanka;
    }

    /**
     * �F�����i�V���̂݁j���擾����
     *
     * @return �F�����i�V���̂݁j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getColorfee() {
        return _colorfee;
    }

    /**
     * �F�����i�V���̂݁j��ݒ肷��
     *
     * @param colorfee �F�����i�V���̂݁j
     */
    public void setColorfee(BigDecimal colorfee) {
        this._colorfee = colorfee;
    }

    /**
     * �w�藿�i�V���̂݁j���擾����
     *
     * @return �w�藿�i�V���̂݁j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDesignationfee() {
        return _designationfee;
    }

    /**
     * �w�藿�i�V���̂݁j��ݒ肷��
     *
     * @param designationfee �w�藿�i�V���̂݁j
     */
    public void setDesignationfee(BigDecimal designationfee) {
        this._designationfee = designationfee;
    }

    /**
     * ��A�ŗ��i�V���̂݁j���擾����
     *
     * @return ��A�ŗ��i�V���̂݁j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDoublefee() {
        return _doublefee;
    }

    /**
     * ��A�ŗ��i�V���̂݁j��ݒ肷��
     *
     * @param doublefee ��A�ŗ��i�V���̂݁j
     */
    public void setDoublefee(BigDecimal doublefee) {
        this._doublefee = doublefee;
    }

    /**
     * �g�֗��i�V���̂݁j���擾����
     *
     * @return �g�֗��i�V���̂݁j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getReclassificationfee() {
        return _reclassificationfee;
    }

    /**
     * �g�֗��i�V���̂݁j��ݒ肷��
     *
     * @param reclassificationfee �g�֗��i�V���̂݁j
     */
    public void setReclassificationfee(BigDecimal reclassificationfee) {
        this._reclassificationfee = reclassificationfee;
    }

    /**
     * �ό`�X�y�[�X���i�V���̂݁j���擾����
     *
     * @return �ό`�X�y�[�X���i�V���̂݁j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSpacefee() {
        return _spacefee;
    }

    /**
     * �ό`�X�y�[�X���i�V���̂݁j��ݒ肷��
     *
     * @param spacefee �ό`�X�y�[�X���i�V���̂݁j
     */
    public void setSpacefee(BigDecimal spacefee) {
        this._spacefee = spacefee;
    }

    /**
     * �X�v���b�g�������i�V���̂݁j���擾����
     *
     * @return �X�v���b�g�������i�V���̂݁j
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSplitrunfee() {
        return _splitrunfee;
    }

    /**
     * �X�v���b�g�������i�V���̂݁j��ݒ肷��
     *
     * @param splitrunfee �X�v���b�g�������i�V���̂݁j
     */
    public void setSplitrunfee(BigDecimal splitrunfee) {
        this._splitrunfee = splitrunfee;
    }

    /**
     * �˗���i�V���̂݁j���擾����
     *
     * @return �˗���i�V���̂݁j
     */
    public String getRequestdestination() {
        return _requestdestination;
    }

    /**
     * �˗���i�V���̂݁j��ݒ肷��
     *
     * @param requestdestination �˗���i�V���̂݁j
     */
    public void setRequestdestination(String requestdestination) {
        this._requestdestination = requestdestination;
    }

    /**
     * ���������擾����
     *
     * @return ������
     */
    public String getBrddate() {
        return _brddate;
    }

    /**
     * ��������ݒ肷��
     *
     * @param brddate ������
     */
    public void setBrddate(String brddate) {
        this._brddate = brddate;
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getBiko() {
        return _biko;
    }

    /**
     * ���l��ݒ肷��
     *
     * @param biko ���l
     */
    public void setBiko(String biko) {
        this._biko = biko;
    }

    /**
     * �����Ώۃt���O���擾����
     *
     * @return �����Ώۃt���O
     */
    public String getSeikyuflg() {
        return _seikyuflg;
    }

    /**
     * �����Ώۃt���O��ݒ肷��
     *
     * @param seikyuflg �����Ώۃt���O
     */
    public void setSeikyuflg(String seikyuflg) {
        this._seikyuflg = seikyuflg;
    }

    /**
     * ���t�ݒ�(���W�I�^�C���̂�)���擾����
     *
     * @return ���t�ݒ�(���W�I�^�C���̂�)
     */
    public String getCpdate() {
        return _cpdate;
    }

    /**
     * ���t�ݒ�(���W�I�^�C���̂�)��ݒ肷��
     *
     * @param cpdate ���t�ݒ�(���W�I�^�C���̂�)
     */
    public void setCpdate(String cpdate) {
        this._cpdate = cpdate;
    }

    /**
     * �b��(���W�I�^�C���̂�)���擾����
     *
     * @return �b��(���W�I�^�C���̂�)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBrdsec() {
        return _brdsec;
    }

    /**
     * �b��(���W�I�^�C���̂�)��ݒ肷��
     *
     * @param brdsec �b��(���W�I�^�C���̂�)
     */
    public void setBrdsec(BigDecimal brdsec) {
        this._brdsec = brdsec;
    }

    /**
     * �󒍃t�@�C���o�̓t���O�i�V���̂݁j���擾����
     *
     * @return �󒍃t�@�C���o�̓t���O�i�V���̂݁j
     */
    public String getFileoutflg() {
        return _fileoutflg;
    }

    /**
     * �󒍃t�@�C���o�̓t���O�i�V���̂݁j��ݒ肷��
     *
     * @param fileoutflg �󒍃t�@�C���o�̓t���O�i�V���̂݁j
     */
    public void setFileoutflg(String fileoutflg) {
        this._fileoutflg = fileoutflg;
    }

    /**
     * �f�ړ����擾����
     *
     * @return �f�ړ�
     */
    @XmlElement(required = true, nillable = true)
    public Date getAppearancedate() {
        return _appearancedate;
    }

    /**
     * �f�ړ���ݒ肷��
     *
     * @param appearancedate �f�ړ�
     */
    public void setAppearancedate(Date appearancedate) {
        this._appearancedate = appearancedate;
    }

    /**
     * �\�[�g�����擾����
     *
     * @return �\�[�g��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * �\�[�g����ݒ肷��
     *
     * @param sortno �\�[�g��
     */
    public void setSortno(BigDecimal sortno) {
        this._sortno = sortno;
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrtdate() {
        return _crtdate;
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param crtdate �f�[�^�쐬����
     */
    public void setCrtdate(Date crtdate) {
        this._crtdate = crtdate;
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCrtnm() {
        return _crtnm;
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param crtnm �f�[�^�쐬��
     */
    public void setCrtnm(String crtnm) {
        this._crtnm = crtnm;
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCrtapl() {
        return _crtapl;
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param crtapl �쐬�v���O����
     */
    public void setCrtapl(String crtapl) {
        this._crtapl = crtapl;
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCrtid() {
        return _crtid;
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param crtid �쐬�S����ID
     */
    public void setCrtid(String crtid) {
        this._crtid = crtid;
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpddate() {
        return _upddate;
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param upddate �f�[�^�X�V����
     */
    public void setUpddate(Date upddate) {
        this._upddate = upddate;
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUpdnm() {
        return _updnm;
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param updnm �f�[�^�X�V��
     */
    public void setUpdnm(String updnm) {
        this._updnm = updnm;
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param updapl �X�V�v���O����
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUpdid() {
        return _updid;
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param updid �X�V�S����ID
     */
    public void setUpdid(String updid) {
        this._updid = updid;
    }

}
